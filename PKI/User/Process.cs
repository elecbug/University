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

        public Process(RSAParameters rsa)
            : base(new Random(DateTime.Now.Microsecond).Next(1, int.MaxValue), new TcpClient())
        {
            RSACryptoServiceProvider r = new RSACryptoServiceProvider();
            r.ImportParameters(rsa);

            CaPublicKey = r.ExportRSAPublicKey();
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
                    ca.ImportRSAPublicKey(CaPublicKey, out o);

                    byte[] crypto = Command.StringToByteArray(split[4]);

                    if (ca.VerifyData(Command.Sign, crypto, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1))
                    {
                        byte[] data = Command.StringToByteArray(split[3]);

                        Console.WriteLine("Verified key! Get key from CA, Your private key is [" + Command.ByteArrayToString(data) + "]");
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
            if (text.Split(' ')[0] == Command.GetKey)
            {
                Client.GetStream()
                    .WriteAsync(Encoding.UTF8.GetBytes(Command.Create(Id, 0, Command.GetKey, text.Split(' ')[1])));
            }
            else
            {
                switch (text)
                {
                    case Command.GenerateKey:
                        Client.GetStream()
                            .WriteAsync(Encoding.UTF8.GetBytes(Command.Create(Id, 0, Command.GenerateKey)));
                        break;
                    default:
                        Console.WriteLine("Invalid text");
                        break;

                }
            }
        }
    }
}
