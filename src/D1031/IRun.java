package D1031;

import java.util.Scanner;

public interface IRun {

    default void menu()
    {
        System.out.println("메뉴를 선택하세요.\n1) 입력\n2) 검색\n3)명단");
        
        Scanner scanner = new Scanner(System.in);

        

        scanner.close();
    }

    abstract void run();
}
