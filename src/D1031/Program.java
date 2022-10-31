package D1031;

public class Program {
    public static void main(String[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            Process process = new Process();
            process.run(i);
        }
    }
}
