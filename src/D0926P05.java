import java.util.Scanner;

class Grade
{
	int math;
	int science;
	int english;
	
	public Grade(int math, int science, int english)
	{
		this.math = math;
		this.science = science;
		this.english = english;
	}
	
	public int sum()
	{
		return this.math + this.science + this.english;
	}
	
	public int average()
	{
		return sum() / 3;
	}
}

public class D0926P05 
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
