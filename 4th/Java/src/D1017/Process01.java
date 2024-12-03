package D1017;

import java.util.Scanner;

public class Process01 {
    public void run()
    {
        Scanner scanner = new Scanner(System.in);

        for (int t = 0; t < 4; t++)
        {
            System.out.println("연산을 입력하세요.");
            String str = scanner.nextLine();
            String[] splits = new String[3];
            int opPoint = 0;
            int a, b;
    
            for (int i = 0; i < str.length(); i++)
            {
                if (str.charAt(i) == '+' || str.charAt(i) == '-' ||
                    str.charAt(i) == '*' || str.charAt(i) == '/')
                {
                    opPoint = i;
                }
            }
    
            splits[0] = str.substring(0, opPoint);
            splits[1] = str.substring(opPoint, opPoint + 1);
            splits[2] = str.substring(opPoint + 1, str.length());
    
            a = Integer.parseInt(splits[0]);
            b = Integer.parseInt(splits[2]);
            
            Calculate cal = null;

            switch(splits[1])
            {
                case "+": cal = new Add(a, b); break;
                case "-": cal = new Sub(a, b); break;
                case "*": cal = new Mul(a, b); break;
                case "/": cal = new Div(a, b); break;
            }

            System.out.println("연산 결과: " + cal.calculate());
        }

        scanner.close();
    }
}
