package D1031;

public class Person implements Comparable<Person>{
    String name;
    int point;
    
    public Person(String name, int point)
    {
        this.name = name;
        this.point = point;
    }

    public void addPoint(int point)
    {
        this.point += point;
    }

    public String getName()
    {
        return this.name;
    }

    public int getPoint()
    {
        return this.point;
    }

    @Override
    public int compareTo(Person o) {
        return this.name.compareTo(o.name);
    }

    
}
