package HW2;

public class People 
{
    private int schoolNum;
    private String name;
    private String major;
    private String phoneNum;  
    private Subject[] subjects; 

    public People(String name, String major, int schoolNum, String phoneNum)
    {
        this.name = name;
        this.major = major;
        this.schoolNum = schoolNum;
        this.phoneNum = phoneNum;
        this.subjects = new Subject[0];
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

    public void addSubject(Subject subject) {}

    public boolean findSubject(Subject subject)
    {
        for (int i = 0; i < this.subjects.length; i++)
        {
            if (this.subjects[i] == subject)
            {
                return true;
            }
        }

        return false;
    }

    protected Subject[] getSubjects()
    {
        return this.subjects;
    }

    protected void setSubjects(Subject[] subjects)
    {
        this.subjects = subjects;
    }
}
