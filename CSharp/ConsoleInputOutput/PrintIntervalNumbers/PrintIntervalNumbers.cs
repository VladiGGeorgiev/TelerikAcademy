/* 8.Write a program that reads an integer number n
 * from the console and prints all the numbers 
 * in the interval [1..n], each on a single line.
*/
using System;

class PrintIntervalNumbers
{
    static void Main()
    {
        Console.WriteLine("Insert number n: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}
