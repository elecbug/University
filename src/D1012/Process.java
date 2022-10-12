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
        while (true)
        {
            int select = -1;

            while(select == -1)
            {
                System.out.println("예약: 1, 조회: 2, 취소: 3, 끝내기: 4");
                try
                {
                    select = scanner.nextInt();

                    switch(select)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        default : throw new Exception();
                    }
                }
                catch(Exception e)
                {
                    
                }
            }
        }
    }
}
