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
        private byte[] CaPublicKey { get; set; }

        public Process(byte[] caPublicKey)
            : base(new Random(DateTime.Now.Microsecond).Next(1, int.MaxValue), new TcpClient())
        {
            CaPublicKey = caPublicKey;
        }

        public void GetPublicKeyPair()
        {
            
        }

        public override void ReadMethod(string text)
        {
            string[] split = Command.Split(text);

            switch (split[2])
            {
                case Command.RecvKey:
                    int o;

                    RSA ca = RSA.Create(1024);

                    byte[] crypto = Convert.FromBase64String(split[4]);

                    Console.WriteLine(Command.ByteArrayToString(crypto));

                    if (ca.VerifyData(Command.Sign, crypto, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1))
                    {
                        byte[] data = Command.StringToByteArray(split[3]);

                        Console.WriteLine("Get key from CA, Your private key is [" + Command.ByteArrayToString(data) + "]");
                    }
                    else
                    {
                        Console.WriteLine("Invalid verify");
                    }

                    break;
            }
        }

        public override void WriteMethod(string text)
        {
            switch (text)
            {
                case Command.GetKey:
                    Client.GetStream()
                        .WriteAsync(Encoding.UTF8.GetBytes(Command.Create(Id, 0, Command.GetKey)));
                    break;
                default:
                    Console.WriteLine("Invalid text");
                    break;

            }
        }
    }
}
