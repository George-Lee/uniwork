using System;

class pricing
{
	static void Main()
	{
		int basePrice = 99;
		Console.WriteLine("How many are you ordering?");
		string orderText=Console.ReadLine();
		int orderNum = int.Parse(orderText);

        if (orderNum>=5)
        {
		    Console.WriteLine("You're getting a 10% discount! That means it'll cost you £" + basePrice*orderNum*0.9);
        }
        else if (orderNum>=10)
        {
			Console.WriteLine("You're getting a 20% discount! That means it'll cost you £" + basePrice*orderNum*0.8);
        }
        else if (orderNum>=20)
        {
			Console.WriteLine("You're getting a 30% discount! That means it'll cost you £" + basePrice*orderNum*0.7);
        }
        else if (orderNum>=50)
        {
			Console.WriteLine("You're getting a 40% discount! That means it'll cost you £" + basePrice*orderNum*0.6);
        }
        else if (orderNum>=100)
        {
			Console.WriteLine("You're getting a 50% discount! That means it'll cost you £" + basePrice*orderNum*0.5);
        }
        else
        {
			Console.WriteLine("You're getting no discount. That means it'll cost you £" + basePrice*orderNum);
        }
	}
}
