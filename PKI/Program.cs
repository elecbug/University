using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

public class Program
{
    public static IPAddress TcpIp = IPAddress.Parse("127.0.0.1");
    public static int TcpPort = 25698;

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, Is started PKI service simulator.");
        Console.WriteLine("What do you want to do role?");
        Console.WriteLine("0. Web Server: The trust PKI system.");
        Console.WriteLine("1. CA:         The trust PKI system.");
        Console.WriteLine("2. User:       User who receive normally service.");
        Console.WriteLine("3. Observer:   Role that can secretly collect all packets and send fake packets (like Trudy)");

        RSA usingCA = RSA.Create(2048);

        while (true)
        {
            try
            {
                int num = int.Parse(Console.ReadLine()!);

                switch (num)
                {
                    case 0: new WebServer().Run();
                            break;
                    case 1: new PKI.CA.Process(usingCA).Run(); 
                        break;
                    case 2: new PKI.User.Process(usingCA.ExportRSAPublicKey()).Run();
                        break;
                    case 3: new PKI.Observer.Process(usingCA.ExportRSAPublicKey()).Run(); 
                        break;
                    default: throw new Exception();
                }

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid text.\n" + ex.ToString());
                continue;
            }
        }

        while (true);
    }
}