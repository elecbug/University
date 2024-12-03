package D1005;

public class Sub 
{
    private int a, b;

    public Sub() {}

    public void setValue(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public int calculate()
    {
        return this.a - this.b;
    }   
}
