import java.util.Scanner;

class D0926P01
{
	int width;
	int height;
	
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
	
	public static void main(String[] args) 
	{
		Scanner scanner = new Scanner(System.in);
		int width, height;
		width = scanner.nextInt();
		height = scanner.nextInt();
		
		D0926P01 r1 = new D0926P01();
		r1.width = width;
		r1.height = height;
		
		System.out.println("사각형의 너비는 " + r1.getWidth() + ", 높이는 " + r1.getHeight() + ", 넓이는 " + r1.getArea() + "입니다.");
		
		scanner.close();
	}
}

