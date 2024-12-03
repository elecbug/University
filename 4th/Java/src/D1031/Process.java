package D1031;

public class Process {
    
    public void run(int version)
    {
        switch (version)
        {
            case 1 : new ArrayMode().run(); break;
            case 2 : new VectorMode().run(); break;
            case 3 : new ArrayListMode().run(); break;
            case 4 : new HashMapMode().run(); break;
            case 5 : new LinkedListMode().run(); break;
        
            default : break;
        }
    }
}
