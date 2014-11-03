/*
 * Write a program that reads from the console a sequence of positive integer numbers. 
 * The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. 
 * Keep the sequence in List<int>.
*/
namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;

    public class ListStructure
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            ReadNumbersFromConsole(numbers);

            int numbersSum = CalculateNumbersSum(numbers);
            double numbersAverageValue = (double)numbersSum / numbers.Count;

            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine("The sum of sequence is: {0}", numbersSum);
            Console.WriteLine("The average value of sequence is: {0:f2}", numbersAverageValue);
        }
  
        public static void ReadNumbersFromConsole(List<int> numbers)
        {
            string line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                int number = int.Parse(line);
                numbers.Add(number);

                line = Console.ReadLine();
            }
        }
  
        private static int CalculateNumbersSum(List<int> numbers)
        {
            int sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }

            return sum;
        }
    }
}
