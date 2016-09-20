using System;

class Concatination
{
	static void Main()
	{
		string hello = "Hello";
		string comma = ", ";
		string world = "world!";
		string joing = String.Concat(hello, comma, world);
		Console.WriteLine(joing);
	}
}