/*Write a program that can solve these tasks:
Reverses the digits of a number
Calculates the average of a sequence of integers
Solves a linear equation a * x + b = 0
		Create appropriate methods.
		Provide a simple text-based menu for the user to choose which task to solve.
		Validate the input data:
The decimal number should be non-negative
The sequence should not be empty
a should not be equal to 0
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveDifferentTasks
{
    class SolveDifferentTasks
    {
        static void Main()
        {
            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("Make your choice:");
            Console.WriteLine("1. Reverses the digits of a number");
            Console.WriteLine("2. Calculates the average of a sequence of integers");
            Console.WriteLine("3. Solves a linear equation a * x + b = 0");
            byte choice = byte.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: 
                    {
                        Console.Write("Insert number to reverse: ");

                        int number = int.Parse(Console.ReadLine());

                        Console.WriteLine("Reversed number: {0}", ReverseDigits(number));
                    }
                    break;
                case 2:
                    {
                        var numbers = new List<int>();
                        Console.Write("How many numbers do you insert? ");
                        int length = int.Parse(Console.ReadLine());

                        for (int i = 0; i < length; i++)
                        {
                            numbers.Add(int.Parse(Console.ReadLine()));
                        }

                        Console.WriteLine("Average is: {0}", Average(numbers));
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("a * x + b = 0");
                        Console.Write("Insert a: ");
                        int a = int.Parse(Console.ReadLine());
                        Console.Write("Insert b: ");
                        int b = int.Parse(Console.ReadLine());

                        Console.WriteLine("x = {0}", SolveLinearEquation(a, b)); 
                    }
                    break;
                default: Console.WriteLine("Wrong choice!");
                    break;
            }
        }

        private static double SolveLinearEquation(int a, int b)
        {
            double x = -((double)b / a);
            return x;
        }

        private static int Average(List<int> numbers)
        {
            int sumNumbers = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sumNumbers += numbers[i];
            }

            int average = sumNumbers / numbers.Count;
            return average;
        }

        private static int ReverseDigits(int number)
        {
            string stringNumber = number.ToString();
            StringBuilder reversedStringNumber = new StringBuilder();

            for (int i = stringNumber.Length - 1; i >= 0 ; i--)
            {
                reversedStringNumber.Append(stringNumber[i]);
            }

            int reversedNumber = int.Parse(reversedStringNumber.ToString());
            return reversedNumber;
        }
    }
}
