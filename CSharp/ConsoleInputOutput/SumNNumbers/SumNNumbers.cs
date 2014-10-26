/* 7.Write a program that gets a number n and after that 
 * gets more n numbers and calculates and prints their sum
 */
using System;

class SumNNumbers
{
    static void Main()
    {
        Console.Write("Insert numbers N: ");
        int N = int.Parse(Console.ReadLine());

        long numbersCounter = new long();
        for (int i = 0; i < N; i++)
        {
            Console.Write("Insert number: ");
            numbersCounter += short.Parse(Console.ReadLine());
        }
        Console.WriteLine("The sum of numbers is: " + numbersCounter);
    }
}
