using System;

class Admission
{
    static void Main()
    {
        Console.WriteLine("Enter your age in years (as an integer)?");
        string age = Console.Readline();
        
        int ageInt = int.Parse(age);
        
        Console.WriteLine("Your age is " + ageInt);
        
        if (ageInt>=18)
        {
            Console.WriteLine("You may come to uni!");
            if (ageInt>=25)
            {
                Console.WriteLine("You are a mature student!");
                if (ageInt>=60)
                {
                    Console.WriteLine("You won't get money though");
                }
            }
        }
        else
        {
                Console.WriteLine("You're too young to come to uni!");
        }
    }
}