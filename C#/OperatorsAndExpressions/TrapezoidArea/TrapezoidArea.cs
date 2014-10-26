/* 8. Write an expression that calculates 
 * trapezoid's area by given sides a and b and height h.
*/
using System;

class TrapezoidArea
{
    static void Main()
    {
        double a = 5.6;

        double b = 2.5;

        double h = 4;

        double area = (a + b) * h / 2;
        Console.WriteLine("The area is: {0}", area);
    }
}
