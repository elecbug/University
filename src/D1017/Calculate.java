package D1017;

public abstract class Calculate {
    protected int a, b;

    public Calculate(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public abstract int calculate();
}
