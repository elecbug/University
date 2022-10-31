package D1031;

public class Process {
    
    public void run(int version)
    {
        switch (version)
        {
            case 0 : new ArrayMode().run(); break;
            case 1 : new VectorMode().run(); break;
            case 2 : new ArrayListMode().run(); break;
            case 3 : new HashMapMode().run(); break;
            case 4 : new LinkedListMode().run(); break;
        }
    }
}
