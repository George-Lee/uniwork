using System;

class Distance
{
	static void Main()
	{
		Console.Write("What is the speed of the vehicle in MPH? ");
		string speedText = Console.ReadLine();
		Console.Write("How many hours has it travelled? ");
		string hourText = Console.ReadLine();
		double speed = int.Parse(speedText);
		double hour = int.Parse(hourText);
		Console.WriteLine("Hour			Distance Travelled");
		Console.WriteLine("---------------------------------------------");
		int counter = 1;
		while(counter<=hour)
		{
			Console.WriteLine(counter + "				" + counter*speed);
			counter++;
		}
	}
}