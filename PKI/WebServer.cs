using System.Net.Sockets;
using System.Net;
using System.Text;
using PKI;
using System.Diagnostics;

public class WebServer
{
    private class SocketId
    {
        public Socket? Socket {  get; set; }
        public int Id { get; set; }
    }

    private TcpListener Server { get; set; }
    private List<SocketId> Sockets { get; set; }
    private object Locker { get; set; } = new object();

    public WebServer()
    {
        Server = new TcpListener(Program.TcpIp, Program.TcpPort);
        Server.Start();

        Sockets = new List<SocketId>();
    }

    private async void ReadyConnection()
    {
        Socket socket = await Server.AcceptSocketAsync();
        SocketId socketId = new SocketId
        {
            Socket = socket
        };

        lock (Locker)
        {
            Sockets.Add(socketId);
        }

        byte[] buffer = new byte[1024];
        await socket.ReceiveAsync(buffer);

        string strId = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        int id = int.Parse(strId);

        socketId.Id = id;

        buffer = Encoding.UTF8.GetBytes("Your ID is [" + id + "]");
        await socket.SendAsync(buffer);

        Console.WriteLine("Connect client, ID [" + id + "]");

        while (true)
        {
            buffer = new byte[65536];
            
            await socket.ReceiveAsync(buffer);
            string text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            text = text.Trim('\0');
            Debug.WriteLine(text);

            await Toss(text);
        }
    }

    public void Run()
    {
        for (int i = 0; i < 10; i++)
        {
            new Thread(ReadyConnection).Start();
        }
    }

    public async Task Toss(string text)
    {
        string[] split = Command.Split(text);
        int sendId = int.Parse(split[0]);
        int recvId = int.Parse(split[1]);
        SocketId recv;

        lock (Locker)
        {
            recv = Sockets.Where(x => x.Id == recvId).First();
        }

        await recv.Socket!.SendAsync(Encoding.UTF8.GetBytes(text));
    }
}