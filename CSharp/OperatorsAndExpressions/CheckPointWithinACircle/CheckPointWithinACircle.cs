/* 6. Write an expression that checks 
 * if given point (x,  y) is within a circle K(O, 5).
 */

using System;

class CheckPointWithinACircle
{
    static void Main()
    {
        Console.Write("Insert X: ");
        double pointX = double.Parse(Console.ReadLine());
        Console.Write("Insert Y: ");
        double pointY = double.Parse(Console.ReadLine());
        double radius = 5;

        bool checkWithinCircle = (pointX*pointX + pointY*pointY) < radius * radius;

        if (checkWithinCircle)
        {
            Console.WriteLine("The point ({0}, {1}) is in the circle.", pointX, pointY);
        }
        else
        {
            Console.WriteLine("The point ({0}, {1}) is without the circle.", pointX, pointY);
        }
    }
}