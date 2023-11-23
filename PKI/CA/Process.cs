using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PKI.CA
{
    public class Process : BaseProcess
    {
        private class KeyPair
        {
            public int Id { get; set; } 
            public byte[] PublicKey { get; set; } = new byte[2048];
        }

        private RSACryptoServiceProvider UsingCA { get; set; }
        private List<KeyPair> KeyPairs { get; set; }

        public Process(RSACryptoServiceProvider usingCA) : base(0, new TcpClient())
        {
            UsingCA = usingCA;
            KeyPairs = new List<KeyPair>();
        }

        public override async void ReadMethod(string text)
        {
            string[] split = Command.Split(text);
            int send = int.Parse(split[0]);
            int recv = int.Parse(split[1]);

            switch (split[2])
            {
                case Command.GetKey:
                    Console.WriteLine("The user [" + send + "] want to RSA key. Accept?");

                    while (Signal == null) ;

                    if (Signal! == true)
                    {
                        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);

                        KeyPair pair = new KeyPair()
                        { 
                            Id = send,
                            PublicKey = rsa.ExportRSAPublicKey(),
                        };
                        string data = Command.Create(Id, send, Command.RecvKey, 
                            Encoding.UTF8.GetString(rsa.ExportRSAPrivateKey()));

                        KeyPairs.Add(pair);

                        await Client.GetStream().WriteAsync(Encoding.UTF8.GetBytes(data));
                    }
                    else if (Signal! == false)
                    {
                        await Client.GetStream().WriteAsync(Encoding.UTF8.GetBytes(
                            Command.Create(Id, send, Command.Cancel)));
                    }
                    break;
            }
        }

        public override void WriteMethod(string text)
        {
        }
    }
}
