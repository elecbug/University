package D0926;
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
