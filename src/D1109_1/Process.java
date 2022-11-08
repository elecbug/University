package D1109_1;

import java.util.Scanner;

/**
 * 메인 프로세스가 들어있는 클래스로, 커맨드를 받거나 실행하는 역할을 수행할 수 있다.
 */
public class Process 
{
    /**
     * 커맨드 관련 기능을 도와주는 매니저 필드다.
     */
    private CommandManager manager;

    /**
     * 메인 프로세스의 실행 함수로써, 매니저를 초기화하고, 커맨드를 받은 후 실행하는 역할을 수행한다.
     */
    public void run()
    {
        this.manager = new CommandManager();
    
        Scanner s = new Scanner(System.in);

        System.out.println("Hello, Program! You can start program input \"go\"");

        // go를 받기 전까지 커맨드를 입력받는 부분
        while (true)
        {
            System.out.print(">> ");
            String str = s.nextLine();

            if (str.equals("go")) break;

            this.manager.addCommand(str);
        }

        // 커맨드를 실행하는 부분
        for (int pc = 0; pc < this.manager.commandLenght();)
        {
            pc = this.manager.runCommand(pc);
        }

        s.close();
    }
}
