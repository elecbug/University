package HW2;

public class People 
{
    private int schoolNum;
    private String name;
    private String major;
    private String phoneNum;  
    private Class[] classes; 

    public People(String name, String major, int schoolNum, String phoneNum)
    {
        this.name = name;
        this.major = major;
        this.schoolNum = schoolNum;
        this.phoneNum = phoneNum;
        this.classes = new Class[0];
    }

    public int getSchoolNum()
    {
        return this.schoolNum;
    }

    public String getName()
    {
        return this.name;
    }

    public String getMajor()
    {
        return this.major;
    }

    public String getPhoneNum()
    {
        return this.phoneNum;
    }

    public void addClass(Class _class)
    {
        Class[] result = new Class[this.classes.length + 1];
        
        for (int i = 0; i < this.classes.length; i++)
        {
            result[i] = this.classes[i];
        }
        result[result.length - 1] = _class;

        this.classes = result;
    }

    public boolean findClass(Class _class)
    {
        for (int i = 0; i < this.classes.length; i++)
        {
            if (this.classes[i] == _class)
            {
                return true;
            }
        }

        return false;
    }
}
