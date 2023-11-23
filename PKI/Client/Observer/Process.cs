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
        }

        public override void ReadMethod(string text)
        {
        }

        public override void WriteMethod(string text)
        {
        }
    }
}
