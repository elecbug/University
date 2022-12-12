package HW4;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.Serializable;
import java.util.Calendar;

class UserInfo implements Serializable
{
    private String name;
    private int grade;
    private int sum;

    public UserInfo(String name)
    {
        this.name = name;
        this.grade = 0;
        this.sum = 0;
    }

    public int getGrade()
    {
        return this.grade;
    }
    
    public void increaseGrade()
    {
        this.grade += 100;
    }

    public String getName()
    {
        return this.name;
    }
    public void setGrade()
    {
        this.grade = 0;
    }

    public void addSum()
    {
        this.sum += this.grade;
    }

    public int getSum() 
    {
        return this.sum;
    }

    public void write(boolean win) 
    {
        File file = new File("src/HW4/log.txt");
        String str = "Name: " + getName() + "\r\nGrade:" + getGrade() + "\r\nTime: " + Calendar.getInstance().getTime().toString() + 
            "\r\nWin: " + (win ? "True" : "False") + "\r\n\r\n";
        try
        {
            BufferedReader reader = new BufferedReader(new FileReader(file));

            String temp;
            while ((temp = reader.readLine()) != null) 
            {
                str += temp + "\r\n";
            }

            reader.close();  
        
            BufferedWriter writer = new BufferedWriter(new FileWriter(file));
            writer.append(str);
            writer.close();
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
}