using System;

class Bottles
{
	static void Main()
	{
		Console.WriteLine("How many verses do you want to hear?");
		string versesText = Console.ReadLine();
		int verses = int.Parse(versesText);
		while(verses>0)
		{
			if(verses==1)
			{
				Console.WriteLine("1 bottle of beer on the wall, 1 bottle of beer.");
				Console.WriteLine("Take one down and pass it around, 0 bottles of beer on the wall.");
			}
			else if(verses == 2)
			{
				Console.WriteLine("2 bottles of beer on the wall, 2 bottles of beer.");
				Console.WriteLine("Take one down and pass it around, 1 bottle of beer on the wall.");
			}
			else
			{
				int neg = verses--;
				Console.WriteLine(verses + " bottles of beer on the wall, " + verses + " bottles of beer.");
				Console.WriteLine("Take one down and pass it around, " + neg + " bottles of beer on the wall.");
			}
			verses--;
		}
	}
}