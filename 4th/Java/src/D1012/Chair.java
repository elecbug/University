package D1012;

public class Chair 
{
    private String name;

    public Chair(String name)
    {
        this.name = name;
    }

    public String getName()
    {
        return this.name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public String toString()
    {
        if (this.name.equals("") || this.name == null)
            return "- - - ";
        else
            return this.name;
    }
}
