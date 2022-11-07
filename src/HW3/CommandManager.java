package HW3;

import java.util.ArrayList;

/**
 * 핵심 클래스로 커맨드를 관리하고 데이터를 저장하는 역할을 수행한다.
 */
public class CommandManager 
{    
    public final String MOV = "mov", ADD = "add", SUB = "sub", JN0 = "jn0", PRT = "prt";

    /**
     * 모든 입력된 커맨드는 순서대로 해당 리스트에 저장되며, 인덱스를 통해 순차적이나 분기적 접근이 가능하게 한다.
     */
    private ArrayList<Command> commands;

    /**
     * 실행 과정에서 필요한 모든 변수 값들은 해당 리스트에 저장된다.
     */
    private ArrayList<Value> values;

    /**
     * 기본 생성자는 리스트를 초기화한다.
     */
    public CommandManager()
    {
        this.commands = new ArrayList<>();
        this.values = new ArrayList<>();
    }

    /**
     * 한 라인의 커맨드 문자열을 받아 새로운 커맨드를 만들고 그 커맨드를 commands에 저장한다.
     * @param fullCommand 커맨드 한 라인 전체의 문자열이다.
     */
    public void addCommand(String fullCommand)
    {
        Command command = new Command(fullCommand);
        this.commands.add(command);
    }

    /**
     * 현재까지 입력된 전체 커맨드의 길이(=commands의 길이)를 반환한다.
     * @return commands.size()
     */
    public int commandLenght()
    {
        return this.commands.size();
    }

    /**
     * 커맨드 한 줄을 실행한다.
     * @param now 실행되는 커맨드 라인으로, 간단히는 commands의 인덱스와 같다.
     * @return 다음 번에 실행될 커맨드 라인으로, 만약 점프 구문이 아닌 상황이라면 일반적으로 now + 1이다.
     */
    public int runCommand(int now)
    {
        int next = now + 1;

        switch(this.commands.get(now).getOperator())
        {
            // 변수 생성 및 초기화 구문이다.
            case MOV: 
            {
                int index = findValueByName(this.commands.get(now).getParameter());
                int data;

                if (isInteger(this.commands.get(now).getData()))
                {
                    data = Integer.parseInt(this.commands.get(now).getData());
                }
                else
                {
                    int subIndex = findValueByName(this.commands.get(now).getData());
                    data = this.values.get(subIndex).getValue();
                }

                if (index == -1)
                {
                    this.values.add(new Value(this.commands.get(now).getParameter(), data));
                }
                else
                {
                    this.values.remove(index);
                    this.values.add(new Value(this.commands.get(now).getParameter(), data));
                }
            }
            break;

            // 변수에 값을 더하는 구문이다.
            case ADD:
            {
                int index = findValueByName(this.commands.get(now).getParameter());
                int data;

                if (isInteger(this.commands.get(now).getData()))
                {
                    data = Integer.parseInt(this.commands.get(now).getData());
                }
                else
                {
                    int subIndex = findValueByName(this.commands.get(now).getData());
                    data = this.values.get(subIndex).getValue();
                }

                if (index == -1)
                {
                    System.out.println("Not found: " + this.commands.get(now).getParameter());
                    break;
                }
                else
                {
                    this.values.get(index).addValue(data);
                }
            }
            break;
            
            // 변수에 값을 빼내는 구문이다.
            case SUB:
            {
                int index = findValueByName(this.commands.get(now).getParameter());
                int data;

                if (isInteger(this.commands.get(now).getData()))
                {
                    data = Integer.parseInt(this.commands.get(now).getData());
                }
                else
                {
                    int subIndex = findValueByName(this.commands.get(now).getData());
                    data = this.values.get(subIndex).getValue();
                }

                if (index == -1)
                {
                    System.out.println("Not found: " + this.commands.get(now).getParameter());
                    break;
                }
                else
                {
                    this.values.get(index).addValue(-data);
                }
            }
            break;

            // 0이 아니라면 점프하는 구문이다.
            case JN0:
            {
                int index = findValueByName(this.commands.get(now).getParameter());
                int data;

                if (isInteger(this.commands.get(now).getData()))
                {
                    data = Integer.parseInt(this.commands.get(now).getData());
                }
                else
                {
                    int subIndex = findValueByName(this.commands.get(now).getData());
                    data = this.values.get(subIndex).getValue();
                }

                if (index == -1)
                {
                    System.out.println("Not found: " + this.commands.get(now).getParameter());
                    break;
                }

                if (this.values.get(index).getValue() != 0)
                {
                    next = data;
                }
            }
            break;

            // 출력하는 구문이다.
            case PRT:
            {
                int index = findValueByName(this.commands.get(now).getParameter());
                
                System.out.println("[" + this.commands.get(now).getOperator() + " " + 
                    this.commands.get(now).getParameter() + " " + this.commands.get(now).getData()+ "]");

                for (Value value : this.values)
                {
                    System.out.print(value.getName() + ": " + value.getValue() + " ");
                }
                System.out.println();

                System.out.println("Print value: " + this.values.get(index).getValue());
            }
            break;

            // 만약 정의되지 않은 연산 파트일 시 에러 구문을 출력한다.
            default:
            {
                System.out.println("Command run error...");
            }
        }

        return next;
    }

    /**
     * 변수의 이름을 바탕으로 하여 변수가 values에서 저장된 인덱스를 반환한다.
     * @param name 찾을 변수의 이름이다.
     * @return name의 이름을 지닌 변수의 values 내 인덱스다.
     */
    public int findValueByName(String name)
    {
        for (int i = 0; i < this.values.size(); i++)
        {
            if (this.values.get(i).getName().equals(name))
            {
                return i;
            }
        }

        return -1;
    }

    /**
     * 특정 문자열이 숫자로 변환될 수 있는지 확인한다.
     * @param s 바꿀 문자열이다.
     * @return 바뀔 수 있는지 여부로, 바뀔 수 있다면 참이다.
     */
    public boolean isInteger(String s) 
    {
        try 
        { 
            Integer.parseInt(s); 
        } 
        catch(NumberFormatException e) 
        { 
            return false; 
        } 
        catch(NullPointerException e) 
        {
            return false;
        }
        
        return true;
    }
}
