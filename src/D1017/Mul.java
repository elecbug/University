package D1017;

public class Mul extends Calculate {
    public Mul(int a, int b)
    {
        super(a, b);
    }

    @Override
    public int calculate()
    {
        return super.a * super.b;
    }
}
