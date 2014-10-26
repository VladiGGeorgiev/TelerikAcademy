/*8.Write a program that calculates the greatest
 * common divisor (GCD) of given two numbers. 
 * Use the Euclidean algorithm (find it in Internet).
*/
using System;

class GreatestCommonDivisor
{
    static int GCD(int a, int b)
    {
        while (true)
        {
            a = a % b;

            if (a == 0)
            {
                return b;
            }

            b = b % a;

            if (b == 0)
            {
                return a;
            }
        }
    }
    static void Main()
    {
        Console.WriteLine("GCD is:" + GCD(14, 70));
    }
}