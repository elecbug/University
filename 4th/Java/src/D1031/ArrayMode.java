package D1031;

import java.util.Arrays;

public class ArrayMode implements IRun {
    private Person[] persons;

    @Override
    public void run() 
    {
        this.persons = new Person[0];
        
        menu();
    }

    @Override
    public void insertPerson(String name, int point) 
    {
        Person[] temp = new Person[this.persons.length + 1];

        for (int i = 0; i < this.persons.length; i++)
        {
            if (this.persons[i].getName().equals(name))
            {
                this.persons[i].addPoint(point);

                return;
            }

            temp[i] = this.persons[i];
        }

        this.persons = temp;
        this.persons[this.persons.length - 1] = new Person(name, point);
    }

    @Override
    public void searchPerson(String name) 
    {
        for (int i = 0; i < this.persons.length; i++)
        {
            if (this.persons[i].getName().equals(name))
            {
                System.out.println(name + "'s point: " + this.persons[i].getPoint());

                return;
            }
        }

        System.out.println("Not found " + name);
    }

    @Override
    public void showPerson()
    {
        Arrays.sort(this.persons);
        
        for (int i = 0; i < this.persons.length; i++)
        {
            System.out.println((i + 1) + ": " + this.persons[i].getName() +
                ", point: " + this.persons[i].getPoint());
        }
    }
}
