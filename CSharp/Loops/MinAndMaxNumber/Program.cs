/* 3.Write a program that reads from the console a sequence of N
 * integer numbers and returns the minimal and maximal of them.
*/
using System;

class Program
{
    static void Main()
    {
        Console.Write("How many numbers do you want to insert: ");
        int numbersLength = int.Parse(Console.ReadLine());

        int[] numbers = new int[numbersLength];

        int maxNumber = numbers[0];
        int minNumber = numbers[0];

        for (int i = 0; i < numbersLength; i++)
        {
            Console.Write("Insert numbers[{0}]: ", i);
            numbers[i] = int.Parse(Console.ReadLine());

            if (maxNumber < numbers[i])
            {
                maxNumber = numbers[i];
            }
            if (minNumber > numbers[i])
            {
                minNumber = numbers[i];
            }
        }

        Console.WriteLine("\nMaximum number is: " + maxNumber);
        Console.WriteLine("Minimum number is: " + minNumber);
    }
}