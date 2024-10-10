using Hermes.Infrastructure;
using System.Net.Sockets;

internal class Program
{
    private static void Main(string[] args)
    {

        //connecting to the client
        TcpClient client = new TcpClient();
        client.Connect(Constants.TestAddress, Constants.PORT);
        Console.WriteLine("Connected to the server!");

        Messenger inStream = new Messenger();
        Messenger outStream = new Messenger();


        //how we will store the messages leaving
        List<string> outgoingMessages = new List<string>();

        //a task that constantly reads the input from the console and adds to the outgoing messages
        new TaskFactory().StartNew(() =>
        {
            while (true)
            {
                var msg = Console.ReadLine();   
                outgoingMessages.Add(msg);
            }

        });

        while (true)
        {
            ReadPackets();
            SendPackets();
        }

        void ReadPackets()
        {
            var stream = client.GetStream();
            for (int i = 0; i < 10; i++)
            {
                if(stream.DataAvailable)
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    (int opCode, string payload) = inStream.ParseMessagePacket(buffer.Take(bytesRead).ToArray());
                    Console.WriteLine($"Received: [{opCode}] - {payload}]");
                }

            }
        }

        void SendPackets()
        {
            if (outgoingMessages.Count > 0)
            {
                var msg = outgoingMessages[0];
                var packet = outStream.CreateMessagePacket(10, msg);
                client.GetStream().Write(packet);
                outgoingMessages.RemoveAt(0);
            }
        }


    }

}