package D0926;
import java.util.Scanner;

public class Program02
{
	public static void main(String[] args) 
	{
		Scanner scanner = new Scanner(System.in);
		int width, height;
		width = scanner.nextInt();
		height = scanner.nextInt();
		
		Rectangle r1 = new Rectangle(width, height);
		System.out.println("사각형의 너비는 " + r1.getWidth() + ", 높이는 " + r1.getHeight() + ", 넓이는 " + r1.getArea() + "입니다.");
		
		scanner.close();
	}
}
