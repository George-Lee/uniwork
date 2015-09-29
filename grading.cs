using System;

class grading
{
	static void Main()
	{
		Console.WriteLine("What was their mark score?");
		string fuckit = Console.ReadLine();
		int mark = int.Parse(fuckit);
		if(mark>=35)
		{
			if(mark>=40)
			{
				if(mark>=50)
				{
					if(mark>=60)
					{
						if(mark>=70)
						{
							Console.WriteLine("You got an A!");
						}
						else
						{
							Console.WriteLine("You got a B");
						}
					}
					else
					{
						Console.WriteLine("You got a C");
					}
				}
				else
				{
					Console.WriteLine("You got a D");
				}
			}
			else
			{
				Console.WriteLine("You got an E");
			}
		}
		else
		{
			Console.WriteLine("You got an F, you're a moron!");
		}
	}
}