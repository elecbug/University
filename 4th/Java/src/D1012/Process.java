package D1012;

import java.util.Scanner;

public class Process 
{
    private Chair[] sChairs;
    private Chair[] aChairs;
    private Chair[] bChairs;

    public Process()
    {
        this.sChairs = new Chair[10];
        this.aChairs = new Chair[10];
        this.bChairs = new Chair[10];

        for (int i = 0; i < 10; i++)
        {
            this.sChairs[i] = new Chair("");
            this.aChairs[i] = new Chair("");
            this.bChairs[i] = new Chair("");
        }
    }

    public void run()
    {
        Scanner scanner = new Scanner(System.in);
        System.out.println("예약 시스템입니다.");
        int select = -1;

        while (select == -1)
        {
            try
            {
                System.out.println("예약: 1, 조회: 2, 취소: 3, 끝내기: 4");
                
                select = scanner.nextInt();

                switch(select)
                {
                    case 1:
                    {
                        System.out.println("좌석 구분:  S: 1, A: 2, B: 3");
                        select = scanner.nextInt();
                        
                        for (int i = 0; i < 10; i++)
                        {
                            switch(select)
                            {
                                case 1:
                                System.out.print(sChairs[i].toString() + " ");
                                break;

                                case 2:
                                System.out.print(aChairs[i].toString() + " ");
                                break;

                                case 3:
                                System.out.print(bChairs[i].toString() + " ");
                                break;
                            }
                        }
                        System.out.println("\n이름");
                        String name = scanner.next();
                        System.out.println("번호");
                        int num = scanner.nextInt() - 1;

                        switch(select)
                        {
                            case 1:
                            if (!sChairs[num].getName().equals(""))
                            {
                                throw new Exception();
                            }
                            sChairs[num].setName(name);
                            break;

                            case 2:
                            if (!aChairs[num].getName().equals(""))
                            {
                                throw new Exception();
                            }
                            aChairs[num].setName(name);
                            break;

                            case 3:
                            if (!bChairs[num].getName().equals(""))
                            {
                                throw new Exception();
                            }
                            bChairs[num].setName(name);
                            break;
                        }
                    }
                    break;

                    case 2:
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            System.out.print(sChairs[i].toString() + " ");
                        }
                        System.out.println();
                        
                        for (int i = 0; i < 10; i++)
                        {
                            System.out.print(aChairs[i].toString() + " ");
                        }
                        System.out.println();
                        
                        for (int i = 0; i < 10; i++)
                        {
                            System.out.print(bChairs[i].toString() + " ");
                        }
                        System.out.println("\n조회를 완료하였습니다.");
                    }
                    break;
                    
                    case 3:
                    {
                        System.out.println("좌석 구분:  S: 1, A: 2, B: 3");
                        select = scanner.nextInt();
                        
                        for (int i = 0; i < 10; i++)
                        {
                            switch(select)
                            {
                                case 1:
                                System.out.print(sChairs[i].toString() + " ");
                                break;

                                case 2:
                                System.out.print(aChairs[i].toString() + " ");
                                break;

                                case 3:
                                System.out.print(bChairs[i].toString() + " ");
                                break;
                            }
                        }
                        System.out.println("\n이름");
                        String name = scanner.next();
                        boolean check = false;

                        switch(select)
                        {
                            case 1:
                            for (int i = 0; i < 10; i++)
                            {
                                if (sChairs[i].getName().equals(name))
                                {
                                    sChairs[i].setName("");
                                    check = true;
                                }
                            }
                            break;

                            case 2:
                            for (int i = 0; i < 10; i++)
                            {
                                if (aChairs[i].getName().equals(name))
                                {
                                    aChairs[i].setName("");
                                    check = true;
                                }
                            }
                            break;

                            case 3:
                            for (int i = 0; i < 10; i++)
                            {
                                if (bChairs[i].getName().equals(name))
                                {
                                    bChairs[i].setName("");
                                    check = true;
                                }
                            }
                            break;
                        }

                        if (!check)
                        {
                            throw new Exception();
                        }
                    }
                    break;
                    
                    case 4:
                    {
                        select = 0;
                    }
                    break;
                    
                    default : 
                        select = -1; 
                        break; 
                }

                if (select == 0)
                {
                    continue;
                }
                else
                {
                    select = -1;
                }
            }
            catch(Exception e)
            {
                System.out.println("잘못된 입력입니다.");
                select = -1;
                continue;
            }
        }

        scanner.close();
    }
}
