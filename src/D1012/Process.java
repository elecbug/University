package D1012;

public class Process 
{
    private Chair[] sChairs;
    private Chair[] aChairs;
    private Chair[] bChairs;

    public Process()
    {
        this.sChairs = new Chair[10];
        this.aChairs = new Chair[10];
        this.bChairs = new Chair[10];

        for (int i = 0; i < 10; i++)
        {
            this.sChairs[i] = new Chair("");
            this.aChairs[i] = new Chair("");
            this.bChairs[i] = new Chair("");
        }
    }

    public void run()
    {
        
    }
}
