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
        private byte[] RsaPublicKey { get; set; }

        public Process(byte[] rsaPublicKey) : base(-1, new TcpClient())
        {
            RsaPublicKey = rsaPublicKey;
        }
    }
}
