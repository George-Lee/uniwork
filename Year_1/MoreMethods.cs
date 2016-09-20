using System;

class MoreMethods
{
	int x = 5;
	int y = 10;

	public int Foo1()
	{
		x = x+y;
		return x;
	}
	public int Foo2()
	{
		return x-y;
	}
	public static void Main()
	{
		MoreMethods mm = new MoreMethods();
		Console.WriteLine(mm.Foo1());
		Console.WriteLine(mm.Foo2());
	}
}