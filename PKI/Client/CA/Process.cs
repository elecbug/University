using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PKI.Client.CA
{
    public class Process : BaseProcess
    {
        private RSACryptoServiceProvider UsingRSA { get; set; }
        public bool OnlyAccept { get; private set; }

        public Process(RSACryptoServiceProvider rsa) : base(0, new TcpClient())
        {
            UsingRSA = rsa;
            OnlyAccept = false;

            Console.WriteLine("You can provide to accept through [y/n].");
            Console.WriteLine("Only provide to accept if you type " + Command.OnlyAccept[1..]);
        }

        public override async void ReadMethod(string text)
        {
            text = text.TrimEnd('\0');

            string[] split = Command.Split(text);
            int send = int.Parse(split[0]);
            int recv = int.Parse(split[1]);

            switch (split[2])
            {
                case Command.GenerateKey:
                    {
                        Console.WriteLine("The user [" + send + "] want to new RSA key. Accept?");

                        while (Signal == null && OnlyAccept == false) ;

                        if (Signal! == true || OnlyAccept == true)
                        {
                            RSA rsa = RSA.Create(1024);

                            KeyPair pair = new KeyPair()
                            {
                                Id = send,
                                PublicKey = rsa.ExportRSAPublicKey(),
                            };

                            byte[] sign = UsingRSA.SignData(SHA256.HashData(Encoding.UTF8.GetBytes(text)), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                            string data = Command.Create(Id, send, Command.RecvGenKey,
                                Command.ByteArrayToString(rsa.ExportRSAPrivateKey()),
                                Command.ByteArrayToString(sign));

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
                case Command.GetKey:
                    {
                        Console.WriteLine("The user [" + send + "] want to [" + split[3] + "]'s public key. Accept?");

                        while (Signal == null && OnlyAccept == false) ;

                        if (Signal! == true || OnlyAccept == true)
                        {
                            KeyPair? pair = KeyPairs.Where(x => x.Id == int.Parse(split[3])).FirstOrDefault();

                            if (pair == null)
                            {
                                Console.WriteLine("You are not know [" + split[3] + "]'s data.");

                                return;
                            }

                            byte[] sign = UsingRSA.SignData(SHA256.HashData(Encoding.UTF8.GetBytes(text)), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                            string data = Command.Create(Id, send, Command.RecvGetKey,
                                pair!.Id + ":" + Command.ByteArrayToString(pair!.PublicKey),
                                Command.ByteArrayToString(sign));

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
        }

        public override void WriteMethod(string text)
        {
            if (text == Command.OnlyAccept)
            {
                OnlyAccept = true;

                Console.WriteLine("Is only accept mode.");
            }
        }
    }
}
