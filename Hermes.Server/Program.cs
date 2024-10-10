using Hermes.Infrastructure;
using System.Net.Sockets;

internal class Program
{
    private static void Main(string[] args)
    {

        var inStream = new Messenger();
        var outStream = new Messenger();

        List<TcpClient> _clients = [];

        TcpListener listener = new TcpListener(Constants.TestAddress, Constants.PORT);
        listener.Start();

        Console.WriteLine("Server started");

        while (true)
        {

            AcceptClients();
            ReceiveMessage();

        }


        //method to see if there are clients to then listen to
        void AcceptClients()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!listener.Pending()) continue;

                //if a client connection is pending, accept it.
                var client = listener.AcceptTcpClient();
                _clients.Add(client);
                Console.WriteLine(("Client accepted"));
            }
        }

        void ReceiveMessage()
        {
            foreach (var client in _clients)
            {
                NetworkStream stream = client.GetStream();

                if (stream.DataAvailable)
                {
                    //read the data. Need to get size
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    //why offset 0?:
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    (int opCode, string payload) = inStream.ParseMessagePacket(buffer.Take(bytesRead).ToArray());

                    Console.WriteLine($"Received: [{opCode} - {payload}]");
                    Broadcast(client, payload);
                }
            }
        }

        void Broadcast(TcpClient sender, string payload)
        {
            foreach (var client in _clients.Where(x => x != sender))
            {
                //create a message packet and send it to the client
                var packet = outStream.CreateMessagePacket(10, payload);
                client.GetStream().Write(packet);
            }
        }
    }

}