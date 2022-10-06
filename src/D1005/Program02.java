package D1005;

import java.util.Scanner;

public class Program02 
{
    public static void main(String[] args)
    {
        Scanner scanner = new Scanner(System.in);

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

        switch(splits[1])
        {
            case "+": Add add = new Add(); add.setValue(a, b); System.out.println("연산 결과: " + add.calculate()); break;
            case "-": Sub sub = new Sub(); sub.setValue(a, b); System.out.println("연산 결과: " + sub.calculate()); break;
            case "*": Mul mul = new Mul(); mul.setValue(a, b); System.out.println("연산 결과: " + mul.calculate()); break;
            case "/": Div div = new Div(); div.setValue(a, b); System.out.println("연산 결과: " + div.calculate()); break;
        }

        scanner.close();
    }
}
