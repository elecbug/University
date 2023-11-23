using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;
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

        private RSA UsingCA { get; set; }
        private List<KeyPair> KeyPairs { get; set; }

        public Process(RSA usingCA) : base(0, new TcpClient())
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
                        RSA rsa = RSA.Create(1024);

                        KeyPair pair = new KeyPair()
                        { 
                            Id = send,
                            PublicKey = rsa.ExportRSAPublicKey(),
                        };

                        byte[] sign = UsingCA.SignData(Command.Sign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                        Console.WriteLine(Command.ByteArrayToString(sign));

                        string data = Command.Create(Id, send, Command.RecvKey, 
                            Command.ByteArrayToString(rsa.ExportRSAPrivateKey()),
                            Convert.ToBase64String(sign));

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
