package D1109_1;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
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
    public void run() throws IOException
    {
        Scanner s = new Scanner(System.in);

        System.out.println("Hello, Program! You can start program input \"go\"");

        // go를 받기 전까지 커맨드를 입력받는 부분
        while (true)
        {
            if (s.next().equals("go"))
            {
                this.manager = new CommandManager();

                BufferedReader reader = new BufferedReader(new FileReader("input.dat"));
        
                String line = reader.readLine();
                while (line != null)
                {
                    this.manager.addCommand(line);
                    line = reader.readLine();
                }
                reader.close();

                // 커맨드를 실행하는 부분
                for (int pc = 0; pc < this.manager.commandLenght();)
                {
                    pc = this.manager.runCommand(pc);
                }

                BufferedWriter writer = new BufferedWriter(new FileWriter(new File("result.dat")));
                writer.write(this.manager.getOutputs());
                writer.close();
            }
            else
            {
                break;
            }
        }

        s.close();
    }
}
