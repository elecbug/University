package D1026;

import java.util.Arrays;
import java.util.Scanner;

public class Process01 
{
    public void run()
    {
        System.out.println("문장을 입력하세요.");
        Scanner input = new Scanner(System.in);
        String text = input.nextLine().toLowerCase();

        String[] splitter = text.split(" ");

        Arrays.sort(splitter);

        System.out.println("사전 순서 정렬입니다.");
        for (String str : splitter)
        {
            System.out.println(str);
        }

        input.close();
    }
}
