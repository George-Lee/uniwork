using System;

class inchtocm
{
	static void Main()
	{
		Console.WriteLine("How many inches long is this thing?");
		string inches = Console.ReadLine();
		double conversion = 2.54;
		double cm = conversion * (double)int.Parse(inches);
		if(cm>=0)
		{
			Console.WriteLine("That's " + cm + "cm long!");
		}
		else
		{
			Console.WriteLine("That's a negative length! Are you sure you're not a moron?");
		}
	}
}