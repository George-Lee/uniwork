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
        }
    }
}