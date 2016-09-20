using System;

class monthsif
{
	static void Main()
	{
		Console.WriteLine("What's the month?");
		string userInput = Console.ReadLine();
		int number = int.Parse(userInput);
		
		if(number==1)
		{
			Console.WriteLine("It's January");
		}
		else if(number==2)
		{
			Console.WriteLine("It's February");
		}
		else if(number==3)
		{
			Console.WriteLine("It's March");
		}
		else if(number==4)
		{
			Console.WriteLine("It's April");
		}
		else if(number==5)
		{
			Console.WriteLine("It's May");
		}
		else if(number==6)
		{
			Console.WriteLine("It's June");
		}
		else if(number==7)
		{
			Console.WriteLine("It's July");
		}
		else if(number==8)
		{
			Console.WriteLine("It's August");
		}
		else if(number==9)
		{
			Console.WriteLine("It's September");
		}
		else if(number==10)
		{
			Console.WriteLine("It's October");
		}
		else if(number==11)
		{
			Console.WriteLine("It's November");
		}
		else if(number==12)
		{
			Console.WriteLine("It's December");
		}
		else
		{
			Console.WriteLine("You're a moron, that's not a month.");
		}
	}
}