using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PKI.Client.Observer
{
    public class Process : BaseProcess
    {
        private byte[] CaPublicKey { get; set; }

        public Process(byte[] pubKey)
            : base(-1, new TcpClient())
        {
            CaPublicKey = pubKey;

            Console.WriteLine("You are the Observer, You can read all message and write message used fake ID in internet.");
        }

        public override void ReadMethod(string text)
        {
            Console.WriteLine(text.Replace(Command.Splitter, " "));
        }

        public override void WriteMethod(string text)
        {
        }
    }
}
