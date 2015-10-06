using System;

class Average
{
	static void Main()
	{
		string userInput;
		double counter = 0;
		int sum = 0;
		int conversion = 0;
		Console.WriteLine("Enter zero integers until you're bored");
		do
		{
			userInput = Console.ReadLine();
			conversion = int.Parse(userInput);
			sum+=conversion;
			counter++;
		}
		while(conversion!=0);
		counter--;
		double average = sum/counter;
		Console.WriteLine("The average of those numbers was " + average);
	}
}