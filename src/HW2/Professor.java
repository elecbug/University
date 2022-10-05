package HW2;

public class Professor extends People
{
    public Professor(String name, String major, int schoolNum, String phoneNum)
    {
        super(name, major, schoolNum, phoneNum);
    }

    public String toString()
    {
        return "이름: " + getName() + ", 학과" 
            + getMajor() + ", 전화번호: " + getPhoneNum();
    }
}
