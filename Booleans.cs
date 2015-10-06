using System;

class Booleans
{
	static void Main()
	{
		string inputText;
		Console.Write("Enter a number: ");
		inputText = Console.ReadLine();
		int input = int.Parse(inputText);
		IsFizz(input);
		IsBuzz(input);
		IsFizzBuzz(input);
	}
	public bool IsFizz(int input)
	{
		if(input%9==0)
		{
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
			return true;
		}
		else
		{
			return false;
		}
	}
}