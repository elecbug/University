package HW2;

public class Subject 
{
    private int year;
    private int classNum;
    private String name;
    private int grade;
    private Professor prof;
    private Student[] students;

    public Subject(int year, int subjectNum, String name, int grade)
    {
        this.year = year;
        this.classNum = subjectNum;
        this.name = name;
        this.grade = grade;
        this.students = new Student[0];
    }

    public int getSubjectNum()
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

    public void setProfessor(Professor prof)
    {
        this.prof = prof;
    }

    public Professor getProfessor()
    {
        return this.prof;
    }

    public void addStudent(Student studetn)
    {
        if (findStudent(studetn))
        {
            return;
        }
        
        Student[] result = new Student[this.students.length + 1];
        
        for (int i = 0; i < this.students.length; i++)
        {
            result[i] = this.students[i];
        }
        result[result.length - 1] = studetn;

        this.students = result;

        studetn.addSubject(this);
    }

    public boolean findStudent(Student student)
    {
        for (int i = 0; i < this.students.length; i++)
        {
            if (this.students[i] == student)
            {
                return true;
            }
        }

        return false;
    }
}
