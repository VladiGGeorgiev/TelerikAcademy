/* Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class. */
namespace ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;

    class ReverseNumbersWithStack
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            string line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                int number = int.Parse(line);
                numbers.Push(number);

                line = Console.ReadLine();
            }

            while (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Pop());
            }
        }
    }
}
