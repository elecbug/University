using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PKI.Observer
{
    public class Process : BaseProcess
    {
        private byte[] CaPublicKey { get; set; }

        public Process(byte[] caPublicKey) : base(-1, new TcpClient())
        {
            CaPublicKey = caPublicKey;
        }

        public override void ReadMethod(string text)
        {
        }

        public override void WriteMethod(string text)
        {
        }
    }
}
