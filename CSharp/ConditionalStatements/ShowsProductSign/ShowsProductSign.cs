/* 2.Write a program that shows the sign (+ or -)
 * of the product of three real numbers without calculating it. 
 * Use a sequence of if statements.
*/
using System;

class ShowsProductSign
{
    static void Main()
    {
        int a = 5;
        int b = -2;
        int c = -234;

        if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine("The result is null");
        }
        else if (a > 0 && b > 0 && c > 0)
        {
            Console.WriteLine("The result is positive");
        }
        else if (a > 0 && b < 0 && c < 0)
        {
            Console.WriteLine("The result is positive");
        }
        else if (a < 0 && b > 0 && c < 0)
        {
            Console.WriteLine("The result is positive");
        }
        else if ((a < 0 && b < 0 && c > 0))
        {
            Console.WriteLine("The result is positive");
        }
        else
        {
            Console.WriteLine("The result is negative");
        }
    }
}
