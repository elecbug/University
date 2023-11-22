public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, Is started PKI service simulator.");
        Console.WriteLine("What do you want to do role?");
        Console.WriteLine("1. CA:       The trust PKI system.");
        Console.WriteLine("2. User:     User who receive normally service.");
        Console.WriteLine("3. Observer: Role that can secretly collect all packets and send fake packets (like Trudy)");
    }
}