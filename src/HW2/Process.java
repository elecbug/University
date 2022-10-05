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
        // initialize level
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
            while (index == -1)
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

        // use level
        final int RETRY = 0, STUDENT = 1, PROFESSOR = 2, EXIT = 3, APPLY_CLASS = 4, CHECK_CLASS = 5;

        int mode = RETRY;
        while (mode != EXIT)
        {
            while (mode == RETRY)
            {
                System.out.println("접속 모드를 선택하세요.\n1. 학생 모드\n2. 교수 모드\n3. 종료");
                switch(scanner.nextInt())
                {
                    case 1: mode = STUDENT; break;
                    case 2: mode = PROFESSOR; break;
                    case 3: mode = EXIT; break;
                    default: mode = RETRY; break;
                }
                
                if (mode == RETRY)
                {
                    System.out.println("숫자가 잘못되었습니다.");
                }
            }

            switch(mode)
            {
                case STUDENT:
                {
                    while (mode == STUDENT)
                    {
                        System.out.println("할 일을 선택하세요.\n1. 수강 신청\n2. 수강 확인");
                        switch(scanner.nextInt())
                        {
                            case 1: mode = APPLY_CLASS; break;
                            case 2: mode = CHECK_CLASS; break;
                            default: mode = STUDENT; break;
                        }
                      
                        if (mode == STUDENT)
                        {
                            System.out.println("숫자가 잘못되었습니다.");
                        }
                    } 

                    if (mode == APPLY_CLASS)
                    {
                        int index = -1;
                        while (index == -1)
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
                            while (index == -1)
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
                    else if (mode == CHECK_CLASS)
                    {
                        int index = -1;
                        while (index == -1)
                        {
                            System.out.println("학생의 학번을 입력하세요.");
                            index = findStudent(scanner.nextInt());
                            
                            if (index == -1)
                            {
                                System.out.println("학생 정보가 잘못되었습니다.");
                            }
                        }

                        Student student = this.students[index];
                        int gradeSum = 0;

                        System.out.println("학생 정보\n" + student.toString() + "\n수강 과목 목록\n");
                        for (int i = 0; i < this.classes.length; i++)
                        {
                            if (student.findClass(this.classes[i]))
                            {
                                System.out.print(this.classes[i].toString() + ", 담당 교수: " );
                                
                                for (int j = 0; j < this.profs.length; j++)
                                {
                                    if (this.profs[j].findClass(this.classes[i]))
                                    {
                                        System.out.println(this.profs[j].getName());
                                    }
                                }

                                gradeSum += this.classes[i].getGrade();
                            }
                        }
                        System.out.println("총 신청 학점: " + gradeSum);
                    }

                    mode = RETRY;
                } 
                break;

                case PROFESSOR:
                {
                    int index = -1;
                    while (index == -1)
                    {
                        System.out.println("해당 강좌의 강좌 번호를 입력하세요.");
                        index = findClass(scanner.nextInt());
                        
                        if (index == -1)
                        {
                            System.out.println("강좌 정보가 잘못되었습니다.");
                        }
                    }

                    Class _class = this.classes[index];
                    String list = "수강자 목록\n";
                    int sNum = 0;

                    for (int i = 0; i < this.profs.length; i++)
                    {
                        if (this.profs[i].findClass(_class))
                        {
                            System.out.println("담당 교수: " + this.profs[i].toString());
                        }
                    }
                    for (int i = 0; i < this.students.length; i++)
                    {
                        if (this.students[i].findClass(_class))
                        {
                            list += this.students[i].toString(++sNum) + "\n";
                        }
                    }
                    System.out.println("수강 인원: " + sNum + "\n" + list);

                    mode = RETRY;
                } 
                break;
            }
        }

        scanner.close();
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
