package D1005;

import java.util.Scanner;

public class Program01 
{
    public static double toDollar(double won)
    {
        return won / 1403.79;
    }

    public static void main(String[] args)
    {
        Scanner scanner = new Scanner(System.in);

        System.out.println("원화를 입력하세요.");
        System.out.println("변환된 달러: " + toDollar(scanner.nextDouble()));

        scanner.close();
    }
}