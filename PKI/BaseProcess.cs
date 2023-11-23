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
        }
    }
}
