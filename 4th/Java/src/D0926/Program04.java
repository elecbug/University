package D0926;
import java.util.Scanner;

public class Program04 
{
	public static void main(String[] args) 
	{
		Book[] books = new Book[2];
		
		Scanner scanner = new Scanner(System.in);
		
		for (int i = 0; i < books.length; i++)
		{
			System.out.print("제목>>");
			String title = scanner.nextLine();
			
			System.out.print("저자>>");
			String author = scanner.nextLine();
			
			books[i] = new Book(title, author); 
		}
		for (int i = 0; i < books.length; i++)
			books[i].show();
		
		scanner.close();
	}
}
