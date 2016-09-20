using System;

class months
{
	static void Main()
	{
		Console.WriteLine("What's the month?");
		string userInput = Console.ReadLine();
		int number = int.Parse(userInput);
		
		switch(number)
		{
			case 1:
				Console.WriteLine("It's January!");
				break;
			case 2:
				Console.WriteLine("It's February!");
				break;
			case 3:
				Console.WriteLine("It's March!");
				break;
			case 4:
				Console.WriteLine("It's April!");
				break;
			case 5:
				Console.WriteLine("It's May!");
				break;
			case 6:
				Console.WriteLine("It's June!");
				break;
			case 7:
				Console.WriteLine("It's July!");
				break;
			case 8:
				Console.WriteLine("It's August!");
				break;
			case 9:
				Console.WriteLine("It's September!");
				break;
			case 10:
				Console.WriteLine("It's October!");
				break;
			case 11:
				Console.WriteLine("It's November!");
				break;
			case 12:
				Console.WriteLine("It's December!");
				break;
			default:
				Console.WriteLine("That's not a month, you're a moron!");
				break;
		}
	}
}