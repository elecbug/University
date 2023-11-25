using PKI;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.Json;
using System.Xml;

public class Program
{
    public static IPAddress TcpIp = IPAddress.Parse("127.0.0.1");
    public static int TcpPort = 25698;

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, Is started PKI service simulator.");
        Console.WriteLine("What do you want to do role?");
        Console.WriteLine("0. Web Server: Web server");
        Console.WriteLine("1. CA:         The trust PKI system.");
        Console.WriteLine("2. User:       User who receive normally service.");
        Console.WriteLine("3. Observer:   Role that can secretly collect all packets and send fake packets (like Trudy)");

        while (true)
        {
            try
            {
                int num = int.Parse(Console.ReadLine()!);

                if (num == 0)
                {
                    new WebServer().Run();
                }
                else if (num == 1)
                {
                    RSACryptoServiceProvider usingCA = new RSACryptoServiceProvider();
                    byte[] data = usingCA.ExportRSAPublicKey();

                    new PKI.Client.CA.Process(usingCA).Run();

                    using BinaryWriter writer = new BinaryWriter(File.OpenWrite("key.pub"));
                    writer.Write(data);
                }
                else
                {
                    RSA rsa = RSA.Create(1024);
                    using BinaryReader reader = new BinaryReader(File.OpenRead("key.pub"));
                    byte[] data = reader.ReadBytes(1024);
                    
                    switch (num)
                    {
                        case 2:
                            new PKI.Client.User.Process(data).Run();
                            break;
                        case 3:
                            new PKI.Client.Observer.Process(data).Run();
                            break;
                        default: throw new Exception();
                    }
                }

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid text.");
                continue;
            }
        }

        while (true);
    }
}