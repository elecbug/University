using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PKI
{
    public abstract class BaseProcess
    {
        public int Id { get; private set; }
        public TcpClient Client { get; private set; }
        private object Locker { get; set; } = new object();
        protected bool? Signal { get; set; } = null;

        public BaseProcess(int id, TcpClient client)
        {
            Id = id;
            Client = client;
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
                byte[] buffer = new byte[4096];

                await Client.GetStream().ReadAsync(buffer);
                ReadMethod(Encoding.UTF8.GetString(buffer));
            }
        }

        private void WhileWrite()
        {
            while (true)
            {
                Signal = null;

                string? str = Console.ReadLine();

                if (str != null)
                {
                    if (str.ToLower() == "y")
                    {
                        Signal = true;
                    }
                    else if (str.ToLower() == "n")
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
