using System;

class PaintCalculator
{
    static void Main()
    {
        double length = 100;
        double height = 50;

        double gapLength = 10;
        double gapHeight = 2;

        double area = (length * height)-(gapLength * gapHeight);
        double cans = Math.Round(area/100);

        Console.WriteLine(cans);
    }
}
