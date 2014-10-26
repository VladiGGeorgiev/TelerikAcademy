/*Write a method GetMax() with two parameters that returns the bigger of two integers.
 * Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().
*/
using System;

class ReturnBiggerInteger
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("The biggest from {0}, {1} and {2} is: {3}", a, b, c, GetMax(a, GetMax(b, c)));
    }

    static int GetMax(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
}
