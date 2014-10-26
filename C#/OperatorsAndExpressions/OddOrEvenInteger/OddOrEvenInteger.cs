/* 1. Write an expression that checks if given integer is odd or even.
*/
using System;

class OddOrEvenInteger
{
    static void Main()
    {
        Console.Write("Insert a number:");
        int number = int.Parse(Console.ReadLine());
        if (number % 2 == 0)
        {
            Console.WriteLine("The number {0} is Odd.", number);
        }
        else
        {
            Console.WriteLine("The number {0} is Even", number);
        }
    }
}