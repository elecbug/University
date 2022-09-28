import java.util.Scanner;

public class HW1 
{
	public static void main(String[] args) 
	{
		Scanner scanner = new Scanner(System.in);
		int answer = (int)(Math.random() * 10000) % 100;
		boolean retry = true;
		
		System.out.println("숫자를 맞추세요. 0 ~ 99 사이의 숫자가 사용됩니다.");
		do 
		{
			System.out.println("숫자를 하나 입력하세요.");
		
			int value = 0;
			String str = scanner.next();
			
			try 
			{
				value = Integer.parseInt(str);
			}
			catch (Exception e)
			{
				System.out.println("숫자를 입력하세요.");
				continue;
			}
			
			if (value < answer) 
				System.out.println("더 높게");
			else if (value > answer) 
				System.out.println("더 낮게");
			else 
			{
				System.out.println("정답"); 
				break;
			}
			
			while (true)
			{
				System.out.println("계속하시겠습니까? y/n");
				String s = scanner.next();
			
				if (s.equals("y")) 
				{
					retry = true;
					break;
				}
				else if (s.equals("n")) 
				{
					retry = false;
					break;
				}
				
				System.out.println("다시 입력하세요.");
			}
		} while (retry);
		
		System.out.println("게임종료");
		
		scanner.close();
	}
}
