using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PKI.Observer
{
    public class Process : BaseProcess
    {
        private byte[] CaPublicKey { get; set; }

        public Process(RSAParameters rsa)
            : base(-1, new TcpClient())
        {
            RSACryptoServiceProvider r = new RSACryptoServiceProvider();
            r.ImportParameters(rsa);

            CaPublicKey = r.ExportRSAPublicKey();
        }

        public override void ReadMethod(string text)
        {
        }

        public override void WriteMethod(string text)
        {
        }
    }
}
