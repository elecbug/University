package HW2;

public class Professor extends People
{
    public Professor(String name, String major, int schoolNum, String phoneNum)
    {
        super(name, major, schoolNum, phoneNum);
    }

    public String toString()
    {
        return "이름: " + getName() + ", 학과: " 
            + getMajor() + ", 전화번호: " + getPhoneNum();
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

        subject.setProfessor(this);
    }
}
