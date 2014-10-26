/* 6.Write a program that reads the coefficients a, b and c 
 * of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).
*/
using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("Insert a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Insert b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Insert c: ");
        double c = double.Parse(Console.ReadLine());

        double D = b * b - 4 * a * c;

        if (D < 0)
        {
            Console.WriteLine("There aren't any real roots.");
        }
        else if (D == 0)
        {
            double x = (-b + Math.Sqrt(D))/(2*a);
            Console.WriteLine("There is one real root: {0}", x);
        }
        else
        {
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            Console.WriteLine("First root = {0} \nSecond root = {1}", x1, x2);
        }
    }
}
