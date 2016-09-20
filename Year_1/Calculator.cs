using System;

class Calculator
{
	//Public variables required.
	double accumulator;
	double storedNum;
	char storedOperator;

	public double Add(double number1, double number2)
	{
		double output = number1 + number2;
		output = Math.Round(output, 2);
		return output;
	}

	public string Calculate(double number, char operator)
	{
		Calculator calculator = new Calculator();

		if(!storedNum)
		{
			storedNum = number;
		}

		if(storedOperator!='')
		{
			switch(storedOperator)
			{
				case '+':
					storedNum = calculator.Add(storedNum, number);
					break;
				default:
					//Suitable error for case not found
					break;
			}
			storedOperator
		}
		else
		{	
			storedOperator = operator;
		}
	}
}