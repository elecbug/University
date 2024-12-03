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
    /// <summary>
    /// 공인 인증 기관
    /// </summary>
    public class Process : BaseProcess
    {
        /// <summary>
        /// 인증 기관이 사용하는 RSA 키
        /// </summary>
        private RSACryptoServiceProvider UsingRSA { get; set; }
        /// <summary>
        /// 모든 요청을 즉시 승인하는 지 여부
        /// </summary>
        public bool OnlyAccept { get; private set; }

        /// <summary>
        /// CA 형성
        /// </summary>
        /// <param name="rsa"> 사용할 RSA 키 서비스 </param>
        public Process(RSACryptoServiceProvider rsa) : base(0, new TcpClient())
        {
            UsingRSA = rsa;
            OnlyAccept = false;

            Console.WriteLine("You can provide to accept through [y/n].");
            Console.WriteLine("Only provide to accept if you type " + Command.OnlyAccept[1..] + ".");
        }

        public override async void ReadMethod(string text)
        {
            text = text.TrimEnd('\0');

            string[] split = Command.Split(text);
            int send = int.Parse(split[0]);
            int recv = int.Parse(split[1]);

            switch (split[2])
            {
                // 키 생성 요청 응답
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

                            byte[] sign = UsingRSA.SignData(SHA256.HashData(Encoding.UTF8.GetBytes(text 
                                + Command.ByteArrayToString(rsa.ExportRSAPrivateKey()))), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

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
                // 유저의 다른 유저 공개키 요청 응답
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

                            byte[] sign = UsingRSA.SignData(SHA256.HashData(Encoding.UTF8.GetBytes(text 
                                + pair!.Id + ":" + Command.ByteArrayToString(pair!.PublicKey))), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

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
            // 항상 승인 모드
            if (text == Command.OnlyAccept)
            {
                OnlyAccept = true;

                Console.WriteLine("Is only accept mode.");
            }
        }
    }
}
