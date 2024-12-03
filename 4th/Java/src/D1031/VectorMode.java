package D1031;

import java.util.Comparator;
import java.util.Vector;

public class VectorMode implements IRun {
    Vector<Person> persons;

    @Override
    public void run() 
    {
        this.persons = new Vector<>(0);

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
        this.persons.sort(Comparator.naturalOrder());

        for (int i = 0; i < this.persons.size(); i++)
        {
            System.out.println((i + 1) + ": " + this.persons.get(i).getName() +
                ", point: " + this.persons.get(i).getPoint());
        }
    }
}
