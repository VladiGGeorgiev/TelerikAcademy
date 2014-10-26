/* 2. Write a program that reads the radius r 
 * of a circle and prints its perimeter and area.
*/
using System;

class PrintCirclePerimeterArea
{
    static void Main()
    {
        Console.Write("Insert Radius:");
        double circleRadius = double.Parse(Console.ReadLine());

        double circleArea = Math.PI * circleRadius * circleRadius;
        double circlePerimeter = Math.PI * 2 * circleRadius;

        Console.WriteLine("Area is: {0:F2}", circleArea);
        Console.WriteLine("Perimeter is: {0:F2}", circlePerimeter);
    }
}
