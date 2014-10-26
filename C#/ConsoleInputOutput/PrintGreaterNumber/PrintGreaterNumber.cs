/* 5.Write a program that gets two numbers from the console 
 * and prints the greater of them. Don’t use if statements.
*/
using System;

class PrintGreaterNumber
{
    static void Main()
    {
        Console.Write("Insert number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Insert other number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.WriteLine(Math.Max(firstNumber, secondNumber));
    }
}