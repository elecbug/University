package D1031;

import java.util.LinkedList;

public class LinkedListMode implements IRun {
    private LinkedList<Person> persons;

    @Override
    public void run() 
    {
        this.persons = new LinkedList<>();

        menu();
    }

    @Override
    public void insertPerson(String name, int point) 
    {
        for (int i = 0; i < this.persons.size(); i++)
        {
            if (this.persons.get(i).getName().equals(name))
            {
                this.persons.get(i).addPoint(point);

                return;
            }
        }

        this.persons.add(new Person(name, point));
    }

    @Override
    public void searchPerson(String name) 
    {
        for (int i = 0; i < this.persons.size(); i++)
        {
            if (this.persons.get(i).getName().equals(name))
            {
                System.out.println(name + "'s point: " + this.persons.get(i).getPoint());

                return;
            }
        }

        System.out.println("Not found " + name);
    }

    @Override
    public void showPerson()
    {
        for (int i = 0; i < this.persons.size(); i++)
        {
            System.out.println((i + 1) + ": " + this.persons.get(i).getName() +
                ", point: " + this.persons.get(i).getPoint());
        }
    }
}
