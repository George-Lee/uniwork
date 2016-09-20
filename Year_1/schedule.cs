using System ;

class Schedule
{
    static void Main()
    {
        Console.WriteLine("What day is it (as a number)?");
        string day = Console.ReadLine();
        
        int daynum = int.Parse(day);
        
        switch (daynum)
        {
            case 1:
                Console.WriteLine("You're doing crap on Monday");
                break;
            case 2:
                Console.WriteLine("You're doing shit on Tuesday");
                break;
            case 3:
                Console.WriteLine("You're doing nothing on Wednesday");
                break;
            case 4:
                Console.WriteLine("You're doing balls on Thursday");
                break;
            case 5:
                Console.WriteLine("You're sucking dick on Friday");
                break;
            case 6:
                Console.WriteLine("You're bored on Saturday");
                break;
            case 7:
                Console.WriteLine("You do nothing on Sunday");
                break;
            default:
                Console.WriteLine("Enter a proper day, you moron");
                break;
        }
    }
}
