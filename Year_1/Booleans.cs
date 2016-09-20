using System;

class Booleans
{
	//Testing methods
	int totalFizz = 0;
	int totalBuzz = 0;
	int totalFizzBuzz = 0;
	int totalPrime = 0;
	public void BeginTesting()
	{
		totalFizz = 0;
		totalBuzz = 0;
		totalFizzBuzz = 0;
		totalPrime = 0;
	}

	public int TotalFizz()
	{
		return totalFizz;
	}

	public int TotalBuzz()
	{
		return totalBuzz;
	}

	public int TotalFizzBuzz()
	{
		return totalFizzBuzz;
	}

	public int TotalPrime()
	{
		return totalPrime;
	}
	//End of testing methods
	public bool IsFizz(int input)
	{
		if(input%9==0)
		{
			totalFizz++;
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool IsBuzz(int input)
	{
		if(input%13==0)
		{
			totalBuzz++;
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool IsFizzBuzz(int input)
	{
		if(input%9==0 && input%13==0)
		{
			totalFizzBuzz++;
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool IsPrime(int input)
	{
		if(input==1)
		{
			return false;
		}
		for(int i=2; i<input; i++)
		{
			if(input%i == 0)
			{
				return false;
			}
		}
		totalPrime++;
		return true;
	}

	static void Main()
	{
		Booleans bools = new Booleans();
		bools.BeginTesting();
		for(int i = 1; i<10000; i++)
		{
			bools.IsFizz(i);
			bools.IsBuzz(i);
			bools.IsFizzBuzz(i);
			bools.IsPrime(i);
		}
		Console.WriteLine("Total Fizz's: " + bools.TotalFizz());
		Console.WriteLine("Total Buzz's: " + bools.TotalBuzz());
		Console.WriteLine("Total Fizzbuzz's: " + bools.TotalFizzBuzz());
		Console.WriteLine("Total Primes: " + bools.TotalPrime());
		/*string inputText;
		Console.Write("Enter a number: ");
		inputText = Console.ReadLine();
		int input = int.Parse(inputText);*/
		/*if (bools.IsFizzBuzz(input) == true)
		{
			Console.WriteLine("Divisible by 9 and 13");
		}
		else if(bools.IsFizz(input) == true)
		{
			Console.WriteLine("Divisible by 9!");
		}
		else if(bools.IsBuzz(input) == true)
		{
			Console.WriteLine("Divisible by 13!");
		}
		else 
		{

			Console.WriteLine("Neither divisible by 9 nor 13");
		}

		if(bools.IsPrime(input)==true)
		{
			Console.WriteLine("Prime!");
		}
		else
		{
			Console.WriteLine("Not prime!");
		}*/
	}
}