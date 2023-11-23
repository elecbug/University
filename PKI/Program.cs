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
                    RSA usingCA = RSA.Create(1024);
                    RSAParameters data = usingCA.ExportParameters(true);

                    new PKI.CA.Process(data).Run();

                    string str = usingCA.ToXmlString(false);
                    using StreamWriter writer = new StreamWriter("key.pub");
                    writer.Write(str);
                }
                else
                {
                    RSA rsa = RSA.Create(1024);
                    using StreamReader reader = new StreamReader("key.pub");
                    string str = reader.ReadToEnd();
                    rsa.FromXmlString(str);
                    RSAParameters data = rsa.ExportParameters(false);
                    
                    switch (num)
                    {
                        case 2:
                            new PKI.User.Process(data).Run();
                            break;
                        case 3:
                            new PKI.Observer.Process(data).Run();
                            break;
                        default: throw new Exception();
                    }
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