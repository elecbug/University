package D0926;
class Rectangle
{
	int width;
	int height;
	
	public Rectangle(int width, int height)
	{
		this.width = width;
		this.height = height;
	}
	
	public int getWidth()
	{
		return this.width;
	}
	
	public int getHeight()
	{
		return this.height;
	}
	
	public int getArea()
	{
		return this.width * this.height;
	}
}
