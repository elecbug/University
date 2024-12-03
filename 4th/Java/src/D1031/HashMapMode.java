package D1031;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;

public class HashMapMode implements IRun {
    private HashMap<String, Integer> persons;

    @Override
    public void run() 
    {
        this.persons = new HashMap<>(0);

        menu();
    }

    @Override
    public void insertPerson(String name, int point) 
    {
        Integer before = this.persons.get(name);
        if (before != null)
        {
            this.persons.remove(name);
            this.persons.put(name, before + point);
        }
        else
        {
            this.persons.put(name, point);
        }
    }

    @Override
    public void searchPerson(String name) 
    {
        if (this.persons.get(name) != null)
        {
            System.out.println(name + "'s point: " + this.persons.get(name));
        
            return;
        }

        System.out.println("Not found " + name);
    }

    @Override
    public void showPerson()
    {
        int index = 1;

        List<String> employeeByKey = new ArrayList<>(this.persons.keySet());
        Collections.sort(employeeByKey);

        for (String key : employeeByKey) 
        {
            System.out.println((index++) + ": " + key + ", point: " + this.persons.get(key));
        }
    }
}
