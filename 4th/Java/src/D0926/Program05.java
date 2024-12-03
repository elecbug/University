package D0926;
import java.util.Scanner;

public class Program05 
{
	public static void main(String[ ] argc) 
	{
		Scanner scanner = new Scanner(System.in);
		System.out.print("수학, 과학, 영어 순으로 3개의 점수 입력 >> ");
		
		int math = scanner.nextInt( );
		int science = scanner.nextInt( );
		int english = scanner.nextInt( );
		
		Grade me = new Grade(math, science, english);
		System.out.println("합은 " + me.sum( ));
		System.out.println("평균은 " + me.average( ));
		scanner.close( );
	}
}
