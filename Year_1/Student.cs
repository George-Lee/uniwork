using System;

public class Student
{
	public bool IsMature(int age)
	{
		if(age>25)
		{
			return true;
		}
		else
		{
			return false;	
		}
	}

	public void HomeTown(string homeTown)
	{
		switch(homeTown)
		{
			case "Derby":
			case "derby":
				Console.WriteLine("This student does not require accomodation.");
				break;
			default:
				Console.WriteLine("This student does not live in Derby, they will require accomodation.");
				break;
		}
	}

	public int YearsRemaining(int yearsStudied)
	{
		return 3-yearsStudied;
	}

	static void Main()
	{
		Student queries = new Student();
		//First, let's just say hello.
		Console.WriteLine("Welcome to the \nUniversity of Derby's \nStudent Enquiry System");
		
		//Now let's grab their name
		Console.Write("Please enter the name of the student: ");
		string studentName = Console.ReadLine();
		
		//Their student number
		Console.Write("Please enter their student number: ");
		int studentNumber = int.Parse(Console.ReadLine());
		
		//Their age
		Console.Write("Please enter student's age: ");
		int age = int.Parse(Console.ReadLine());
		
		//Their hometown
		Console.Write("Please enter town of residence: ");
		string town = Console.ReadLine();

		//Course information (Length of study and current year)
		Console.Write("Please enter current year of study: ");
		int currentYear = int.Parse(Console.ReadLine());

		//Now we display the student summary screen.
		
		Console.WriteLine("***************************************");
		Console.WriteLine("* Summary for "+studentName+": "+studentNumber);
		Console.WriteLine("***************************************");
		Console.WriteLine("Age: "+age);
		if(queries.IsMature(age)==true)
		{
			Console.WriteLine("This student is considered a mature student.");
		}
		Console.WriteLine("From: "+town);
		queries.HomeTown(town);
		Console.WriteLine("The student has " + queries.YearsRemaining(currentYear) + " year(s) remaining in their course");
		/* Next we want to see code for the following:
		
			1) Calling a method that calculates the number of years study remaining.
			2) Call a method that tells us whether the student is not from Derby.  This will then display an outcome regards student accomodation.
			3) Is a mature student.
		*/
	}

}