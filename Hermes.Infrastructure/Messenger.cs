using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Infrastructure
{
    /// <summary>
    /// Class that creates the condition for a string message
    /// to be passed between client and server.
    /// </summary>
    public class Messenger
    {
        /// <summary>
        /// Creates a packet that includes an int to identify the 
        /// operation code, and a string atht is the payload
        /// </summary>
        /// <param name="opCode"></param>
        /// <param name="message"></param>
        /// <returns>byte[]</returns>
        public byte[] CreateMessagePacket(int opCode, string payload)
        {
            //memory stream holds the data, and binary writer
            //translates this to a byte array
            using MemoryStream ms = new MemoryStream();
            using BinaryWriter writer = new BinaryWriter(ms);

            writer.Write(opCode);
            writer.Write(payload);

            return ms.ToArray();
        }

        /// <summary>
        /// Parses a back that has been sent. Takes a 
        /// byte array and returns a tuple of opCode and payload.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Tuple</returns>
        public (int opCode, string payload) ParseMessagePacket(byte[] data)
        {
            using MemoryStream ms = new MemoryStream();
            using BinaryReader reader = new BinaryReader(ms);

            int opCode = reader.ReadInt32();
            string payload = reader.ReadString();

            return (opCode, payload);   
        }
    }
}
