package D1017;

public class Div extends Calculate {
    public Div(int a, int b)
    {
        super(a, b);
    }

    @Override
    public int calculate()
    {
        return super.a / super.b;
    }
}
