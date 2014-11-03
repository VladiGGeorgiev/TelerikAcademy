using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNegativeNumbers
{
    class RemoveNegativeNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() 
            { 
                2, 4, 6, -3, 2, -5, 1, 3, -12, 32, 43, -54, 43, -9
            };

            Console.WriteLine(string.Join(" ", numbers));

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ",  numbers));
        }
    }
}
