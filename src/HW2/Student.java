package HW2;

public class Student extends People
{
    private int nTh;

    public Student(String name, String major, int schoolNum, String phoneNum, int nTh)
    {
        super(name, major, schoolNum, phoneNum);
        this.nTh = nTh;
    }

    public void setNTh(int nTh)
    {
        this.nTh = nTh;
    }

    public int getNth()
    {
        return this.nTh;
    }
    
    public String toString()
    {
        return "학생 정보: " + this.getName() + " " + this.getSchoolNum() + " "  + this.getMajor() + " "  + this.getNth();
    }
}
