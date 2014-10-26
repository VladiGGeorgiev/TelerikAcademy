/* 1. Write a program that reads 3 integer numbers
 * from the console and prints their sum.
*/
using System;

class ReadAndSumNumbers
{
    static void Main()
    {
        Console.Write("Insert a:");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Insert b:");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Insert c:");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, (a + b + c));
    }
}
