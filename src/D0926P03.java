
class Book
{
	private String title;
	private String author;
	
	public Book(String title, String author)
	{
		this.title = title;
		this.author = author;
	}
	
	public Book(String title)
	{
		this(title, "작자미상");
	}
	
	public Book()
	{
		this("", "");
	}
	
	public void show()
	{
		System.out.println(this.title + ", " + this.author);
	}
}

public class D0926P03 
{
	public static void main(String[] args) 
	{
		Book littlePrince = new Book("어린왕자", "생텍쥐페리");
		Book loveStory = new Book("춘향전");
		Book emptyBook = new Book();
		littlePrince.show();
		loveStory.show();
		emptyBook.show();
	}
}
