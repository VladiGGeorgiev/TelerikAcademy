/* 4.Write a program that reads two positive integer numbers
 * and prints how many numbers p exist between them such 
 * that the reminder of the division by 5 is 0 (inclusive). 
 * Example: p(17,25) = 2.
*/
using System;

class PrintDevideNumbers
{
    static void Main()
    {
        Console.Write("Insert first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Insert second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        byte pCounter = new byte();
        for (int i = firstNumber; i < secondNumber; i++)
        {
            if (i % 5 == 0)
            {
                pCounter++;
            }
        }
        Console.WriteLine("p({0}, {1}) = {2}", firstNumber, secondNumber, pCounter);
    }
}