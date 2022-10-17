package D1017;

public class Sub extends Calculate {
    public Sub(int a, int b)
    {
        super(a, b);
    }

    @Override
    public int calculate()
    {
        return super.a - super.b;
    }
}
