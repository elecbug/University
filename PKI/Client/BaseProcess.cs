using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PKI.Client
{
    public abstract class BaseProcess
    {
        public class KeyPair
        {
            public int Id { get; set; }
            public byte[] PublicKey { get; set; } = new byte[2048];
        }

        public int Id { get; private set; }
        public TcpClient Client { get; private set; }
        protected bool? Signal { get; set; } = null;
        protected List<KeyPair> KeyPairs { get; set; }

        public BaseProcess(int id, TcpClient client)
        {
            Id = id;
            Client = client;
            KeyPairs = new List<KeyPair>();
        }

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

        private async Task WhileRead()
        {
            while (true)
            {
                byte[] buffer = new byte[65536];

                await Client.GetStream().ReadAsync(buffer);
                ReadMethod(Encoding.UTF8.GetString(buffer));
            }
        }

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

        public abstract void ReadMethod(string text);
        public abstract void WriteMethod(string text);
    }
}
