package HW3;

/**
 * 값을 저장하는 클래스로 각 객체는 이름과 정수 값을 가진다.
 */
public class Value 
{
    private String name;
    private int value;

    /**
     * 이름과 정수 값을 받아서 초기화하는 생성자이다.
     * @param name 변수의 이름이다.
     * @param value 변수의 값이다.
     */
    public Value(String name, int value)
    {
        this.name = name;
        this.value = value;
    }

    /**
     * 현재 객체의 값에 value를 더한다.
     * @param value 더할 value이다.
     */
    public void addValue(int value)
    {
        this.value += value;
    }

    public int getValue()
    {
        return this.value;
    }

    public String getName()
    {
        return this.name;
    }
}
