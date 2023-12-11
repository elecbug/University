using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PKI.Client
{
    /// <summary>
    /// 베이스 프로세스
    /// </summary>
    public abstract class BaseProcess
    {
        /// <summary>
        /// 유저의 아이디와 공개 키 쌍
        /// </summary>
        public class KeyPair
        {
            public int Id { get; set; }
            public byte[] PublicKey { get; set; } = new byte[2048];
        }

        /// <summary>
        /// 유저 아이디
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// TCP 클라이언트
        /// </summary>
        public TcpClient Client { get; private set; }
        /// <summary>
        /// 시그널 신호(y,n 입력)인지 여부를 체크
        /// </summary>
        protected bool? Signal { get; set; } = null;
        /// <summary>
        /// 자신이 알고있는 공개 키 페어의 리스트
        /// </summary>
        protected List<KeyPair> KeyPairs { get; set; }

        /// <summary>
        /// 베이스 프로세스의 생성자
        /// </summary>
        /// <param name="id"> 사용할 아이디 </param>
        /// <param name="client"> TCP 클라이언트 </param>
        public BaseProcess(int id, TcpClient client)
        {
            Id = id;
            Client = client;
            KeyPairs = new List<KeyPair>();
        }

        /// <summary>
        /// 베이스 프로세스를 구동
        /// </summary>
        public async void Run()
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Id.ToString());

            await Client.ConnectAsync(Program.TcpIp, Program.TcpPort);
            await Client.GetStream().WriteAsync(bytes);

            bytes = new byte[4096];

            await Client.GetStream().ReadAsync(bytes);

            Console.WriteLine(Encoding.UTF8.GetString(bytes));

            new Thread(async () => { await WhileRead(); }).Start();
            new Thread(WhileWrite).Start();
        }

        /// <summary>
        /// 읽기 스레드를 무한 루프
        /// </summary>
        /// <returns></returns>
        private async Task WhileRead()
        {
            while (true)
            {
                byte[] buffer = new byte[65536];

                await Client.GetStream().ReadAsync(buffer);
                ReadMethod(Encoding.UTF8.GetString(buffer));
            }
        }

        /// <summary>
        /// 쓰기 스레드를 무한 루프
        /// </summary>
        private void WhileWrite()
        {
            while (true)
            {
                Signal = null;

                string? str = ";" + Console.ReadLine();

                if (Id == -1)
                {
                    str = str[1..];
                }

                if (str != null)
                {
                    if (str.ToLower() == ";y")
                    {
                        Signal = true;
                    }
                    else if (str.ToLower() == ";n")
                    {
                        Signal = false;
                    }

                    WriteMethod(str);
                }
            }
        }

        /// <summary>
        /// 읽기 스레드에서 읽기 발생 시 호출되는 메서드
        /// </summary>
        /// <param name="text"> 읽어 온 텍스트 </param>
        public abstract void ReadMethod(string text);
        /// <summary>
        /// 쓰기 스레드에서 쓰기 발생 시 호출되는 메서드
        /// </summary>
        /// <param name="text"> 쓴 텍스트 </param>
        public abstract void WriteMethod(string text);
    }
}
