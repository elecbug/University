package D1031;

import java.util.Scanner;

public interface IRun {

    default void menu()
    {
        Scanner scanner = new Scanner(System.in);
        
        while (true)
        {
            System.out.println("메뉴를 선택하세요.\n1) 입력\n2) 검색\n3) 명단");

            switch(scanner.nextInt())
            {
                case 1: 
                {
                    String name = "";
                    
                    while (!name.equals("그만"))
                    {
                        name = scanner.next();
                        insertPerson(name, scanner.nextInt()); 
                    }
                }
                break;

                case 2: 
                {
                    String name = "";
                    
                    while (!name.equals("그만"))
                    {
                        name = scanner.next();
                        searchPerson(name); 
                    }
                }
                break;
                
                case 3: 
                {
                    showPerson();
                }
                break;
            }
        }

        scanner.close();
    }

    abstract void run();

    abstract void insertPerson(String name, int point);
    abstract void searchPerson(String name);
    abstract void showPerson();
}
