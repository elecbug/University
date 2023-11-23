using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PKI.User
{
    public class Process : BaseProcess
    {
        private byte[] RsaPublicKey { get; set; }
        private RSA? RSA { get; set; }

        public Process(byte[] rsaPublicKey)
            : base(new Random(DateTime.Now.Microsecond).Next(1, int.MaxValue), new TcpClient())
        {
            RsaPublicKey = rsaPublicKey;
        }

        public void GetPublicKeyPair()
        {
            Client.GetStream()
                .WriteAsync(Encoding.UTF8.GetBytes(Command.Create(Id, 0, Command.GetKey)));
        }
    }
}
