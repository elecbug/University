package D1005;

public class Div
{
    private int a, b;

    public Div() {}

    public void setValue(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public double calculate()
    {
        return this.a / (double)this.b;
    }   
}
