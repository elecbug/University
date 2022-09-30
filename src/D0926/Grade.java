package D0926;

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
