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

    public int getGrade()
    {
        return this.grade;
    }

    public String toString()
    {
        return this.year + "학년도, 강좌번호: " + this.classNum + ", " + this.name + "강의, " + this.grade + "학점";
    }
}
