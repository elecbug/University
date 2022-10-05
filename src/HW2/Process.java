package HW2;

import java.util.Scanner;

public class Process 
{
    private Professor[] profs;
    private Student[] students;
    private Class[] classes;
    
    public Process() 
    {
        this.profs = new Professor[3];
        this.students = new Student[10];
        this.classes = new Class[5];
    }

    public void Run()
    {
        Scanner scanner = new Scanner(System.in);

        for (int i = 0; i < 10; i++)
        {
            System.out.println((i + 1) + "번째 학생의 정보를 입력하세요(이름, 전공, 학생번호, 전화번호, 학년)");
            this.students[i] = new Student(scanner.next(), scanner.next(), scanner.nextInt(), scanner.next(), scanner.nextInt());
        }
        for (int i = 0 ; i < 3; i++)
        {
            System.out.println((i + 1) + "번째 교수의 정보를 입력하세요(이름, 전공, 교수번호, 전화번호)");
            this.profs[i] = new Professor(scanner.next(), scanner.next(), scanner.nextInt(), scanner.next());
        }
        for (int i = 0 ; i < 5; i++)
        {
            System.out.println((i + 1) + "번째 수업의 정보를 입력하세요(년도, 강좌번호, 강좌이름, 학점)");
            this.classes[i] = new Class(scanner.nextInt(), scanner.nextInt(), scanner.next(), scanner.nextInt());
            
            int index = -1;
            for (; index == -1;)
            {
                System.out.println("해당 강좌의 교수님 사번을 입력하세요.");
                index = findProfessor(scanner.nextInt());
                if (index == -1)
                {
                    System.out.println("교수님 정보가 잘못되었습니다.");
                }
            }

            this.profs[index].addClass(this.classes[i]);
        }

        int mode = 0;
        while (mode != 3)
        {
            for (; mode == 0; )
            {
                System.out.println("접속 모드를 선택하세요.\n1. 학생 모드\n2. 교수 모드\n3. 종료");
                switch(scanner.nextInt())
                {
                    case 1: mode = 1; break;
                    case 2: mode = 2; break;
                    case 3: mode = 3; break;
                    default: mode = 0; break;
                }
                if (mode == 0)
                {
                    System.out.println("숫자가 잘못되었습니다.");
                }
            }

            switch(mode)
            {
                case 1:
                {
                    for (; mode == 1; )
                    {
                        System.out.println("할 일을 선택하세요.\n1. 수강 신청\n2. 수강 확인");
                        switch(scanner.nextInt())
                        {
                            case 1: mode = 4; break;
                            case 2: mode = 5; break;
                            default: mode = 1; break;
                        }
                        if (mode == 1)
                        {
                            System.out.println("숫자가 잘못되었습니다.");
                        }
                    } 

                    if (mode == 4)
                    {
                        int index = -1;
                        for (; index == -1; )
                        {
                            System.out.println("학생의 학번을 입력하세요.");
                            index = findStudent(scanner.nextInt());
                            if (index == -1)
                            {
                                System.out.println("학생 정보가 잘못되었습니다.");
                            }
                        }

                        Student student = this.students[index];
                        
                        for (int i = 0 ; i < 3; i++)
                        {
                            index = -1;
                            for (; index == -1; )
                            {
                                System.out.println("강좌 번호를 입력하세요.");
                                index = findClass(scanner.nextInt());
                                if (index == -1)
                                {
                                    System.out.println("강좌 정보가 잘못되었습니다.");
                                }
                            }

                            student.addClass(this.classes[index]);
                        }

                    }
                    else if (mode == 5)
                    {
                        int index = -1;
                        for (; index == -1; System.out.println("학생 정보가 잘못되었습니다."))
                        {
                            System.out.println("학생의 학번을 입력하세요.");
                            index = findStudent(scanner.nextInt());
                            if (index == -1)
                            {
                                System.out.println("학생 정보가 잘못되었습니다.");
                            }
                        }

                        Student student = this.students[index];
                        
                        for (int i = 0; i < this.classes.length; i++)
                        {
                            if (student.findClass(this.classes[i]))
                            {
                                System.out.println(this.classes[i].toString());
                            }
                        }
                    }

                    mode = 0;
                } break;
                case 2:
                {
                    int index = -1;
                    for (; index == -1;)
                    {
                        System.out.println("해당 강좌의 강좌번호를 입력하세요.");
                        index = findClass(scanner.nextInt());
                        if (index == -1)
                        {
                            System.out.println("강좌번호가 잘못되었습니다.");
                        }
                    }

                    Class _class = this.classes[index];
                        
                    for (int i = 0; i < this.students.length; i++)
                    {
                        if (this.students[i].findClass(_class))
                        {
                            System.out.println(this.students[i].toString());
                        }
                    }
                    
                    mode = 0;
                } break;
                
            }
        }
    }

    public void addProfessor(Professor prof)
    {
        Professor[] result = new Professor[this.profs.length + 1];
        
        for (int i = 0; i < this.profs.length; i++)
        {
            result[i] = this.profs[i];
        }
        result[result.length - 1] = prof;

        this.profs = result;
    }

    public void addStudent(Student student)
    {
        Student[] result = new Student[this.students.length + 1];
        
        for (int i = 0; i < this.students.length; i++)
        {
            result[i] = this.students[i];
        }
        result[result.length - 1] = student;

        this.students = result;
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

    public int findProfessor(int schoolNum)
    {
        for (int i = 0; i < this.profs.length; i++)
        {
            if (this.profs[i].getSchoolNum() == schoolNum)
            {
                return i;
            }
        }
        
        return -1;
    }

    public int findStudent(int schoolNum)
    {
        for (int i = 0; i < this.students.length; i++)
        {
            if (this.students[i].getSchoolNum() == schoolNum)
            {
                return i;
            }
        }
        
        return -1;
    }

    public int findClass(int classNum)
    {
        for (int i = 0; i < this.classes.length; i++)
        {
            if (this.classes[i].getClassNum() == classNum)
            {
                return i;
            }
        }
        
        return -1;
    }
}
