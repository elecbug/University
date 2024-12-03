package D1109_1;

/**
 * 하나의 커맨드 단위 클래스로 객체는 연산자 파트, 매개 변수 파트, 데이터 파트로 분할된 커맨드를 저장한다.
 */
public class Command 
{
    private String operator;
    private String parameter;
    private String data;

    /**
     * 전체 문자열을 입력받아 쪼개어 커맨드로 저장하는 생성자로써 쪼갤 수 없을 때 오류 메세지를 출력한다.
     * @param fullCommand 입력받는 전체 문자열이다.
     */
    public Command(String fullCommand)
    {
        String[] split = fullCommand.split(" ");

        try
        {
            this.operator = split[0];
            this.parameter = split[1];
            this.data = split[2];
        }
        catch (Exception e)
        {
            System.out.println("Command input error...");
        }
    }

    public String getOperator()
    {
        return this.operator;
    }

    public String getParameter()
    {
        return this.parameter;
    }

    public String getData()
    {
        return this.data;
    }

    public String getFullString()
    {
        return getOperator() + " " + getParameter() + " " + getData();
    }
}
