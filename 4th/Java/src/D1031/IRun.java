package D1031;

import java.util.Scanner;

public interface IRun {

    default void menu()
    {
        Scanner scanner = new Scanner(System.in);
        boolean roof = true;
        
        while (roof)
        {
            System.out.println("메뉴를 선택하세요.\n1) 입력\n2) 검색\n3) 명단\n4) 종료");

            switch(scanner.nextInt())
            {
                case 1: 
                {
                    String name = "";
                    
                    while (true)
                    {
                        name = scanner.next();
                        
                        if (name.equals("stop")) break;

                        insertPerson(name, scanner.nextInt()); 
                    }
                }
                break;

                case 2: 
                {
                    String name = "";
                    
                    while (true)
                    {
                        name = scanner.next();
                        
                        if (name.equals("stop")) break;

                        searchPerson(name); 
                    }
                }
                break;
                
                case 3: 
                {
                    showPerson();
                }
                break;

                case 4:
                {
                    roof = false;
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
