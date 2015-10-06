using System;

class Multiples
{
	static void Main()
	{
		string factorText;
		Console.Write("Which number would you like to see the multiplication table for? ");
		factorText = Console.ReadLine();
		int factor = int.Parse(factorText);
		int counter = 1;
		while(counter<11)
		{
			Console.WriteLine(counter + " x " + factor + " = " + counter*factor);
			counter++;
		}
	}
}