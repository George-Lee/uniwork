using System;

class Conversion
{
	public double FarToCel(double fahrenheit)
	{
		double celcius = (fahrenheit-32)/1.8;
		return celcius;
	}

	public double CelToFar(double celcius)
	{
		double fahrenheit = 1.8*celcius+32;
		return fahrenheit;
	}

	static void Main()
	{
		Conversion conversions = new Conversion();
		double fahr = 62;
		double celc = 30;
		Console.WriteLine("140 fahrenheit is " + conversions.FarToCel(fahr));
		Console.WriteLine("30 celcius is " + conversions.CelToFar(celc));
	}
}