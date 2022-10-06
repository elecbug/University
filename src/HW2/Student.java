package HW2;

public class Student extends People
{
    private int nTh;

    public Student(String name, String major, int schoolNum, String phoneNum, int nTh)
    {
        super(name, major, schoolNum, phoneNum);
        this.nTh = nTh;
    }

    public int getNth()
    {
        return this.nTh;
    }
    
    public String toString()
    {
        return "학번: " + getSchoolNum() + ", 이름: " + getName() + ", 학과: " 
            + getMajor() + ", 학년" + getNth() + ", 전화번호: " + getPhoneNum();
    }

    public String toString(int num)
    {
        return num + "번: 이름: " + getName() + ", 학번: " + getSchoolNum() + ", 전공:  "  
            + getMajor() + ", 학년: "  + getNth();
    }

    public int getGradeSum()
    {
        int result = 0;

        for (int i = 0; i < getSubjects().length; i++)
        {
            result += getSubjects()[i].getGrade();
        }

        return result;
    }

    @Override
    public void addSubject(Subject subject)
    {
        if (findSubject(subject))
        {
            return;
        }
        
        Subject[] result = new Subject[this.getSubjects().length + 1];
        
        for (int i = 0; i < this.getSubjects().length; i++)
        {
            result[i] = this.getSubjects()[i];
        }
        result[result.length - 1] = subject;

        this.setSubjects(result);

        subject.addStudent(this);
    }
}
