package HW2;

public class Class 
{
    private int year;
    private int classNum;
    private String name;
    private int grade;

    public Class(int year, int classNum, String name, int grade)
    {
        this.year = year;
        this.classNum = classNum;
        this.name = name;
        this.grade = grade;
    }

    public int getClassNum()
    {
        return this.classNum;
    }

    public String toString()
    {
        return "년도: " + this.year + "\n강좌번호: " + this.classNum + "\n강좌이름: " + this.name + "\n학점: " + this.grade;
    }
}
