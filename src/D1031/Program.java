package D1031;

import java.util.Scanner;

public class Program {
    public static void main(String[] args)
    {
        Scanner s = new Scanner(System.in);

        System.out.println("모드를 선택하세요.\n1) Array mode\n2) Vector mode\n3) ArrayList mode\n4) HashMap mode\n5) LinkedList mode");

        Process process = new Process();
        process.run(s.nextInt());
    
        s.close();
    }
}
