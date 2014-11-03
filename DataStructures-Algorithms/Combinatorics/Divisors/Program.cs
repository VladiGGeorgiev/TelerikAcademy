using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisors
{
    class Program
    {
        static int n;
        static List<int> numbers;
        static HashSet<int> results;
        static int[] currentIndexes;
        static bool[] used;
        static string currentNumber;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            numbers = new List<int>();
            results = new HashSet<int>();
            currentIndexes = new int[n];
            used = new bool[n];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers.Add(number);
            }

            FindPermutations(0);

            Console.WriteLine(FindMinimumDivisor()); 
        }

        private static int FindMinimumDivisor()
        {
            int counter = 0;
            int minCounter = int.MaxValue;
            int minDivisorsElement = 0;
            foreach (var item in results)
            {
                for (int j = 1; j < item; j++)
                {
                    if (item % j == 0)
                    {
                        counter++;
                    }
                }

                if (counter < minCounter)
                {
                    minDivisorsElement = item;
                    minCounter = counter;
                }
                else if (counter == minCounter && item < minDivisorsElement)
                {
                    minDivisorsElement = item;
                    minCounter = counter;
                }

                counter = 0;
            }

            return minDivisorsElement;
        }

        private static void FindPermutations(int index)
        {
            if (index == numbers.Count)
            {
                for (int i = 0; i < currentIndexes.Length; i++)
                {
                    currentNumber += numbers[currentIndexes[i]];
                }
                int number = int.Parse(currentNumber);
                
                if (!results.Contains(number))
                {
                    results.Add(number);
                }
                currentNumber = string.Empty;
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    currentIndexes[index] = i;
                    used[i] = true;
                    FindPermutations(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
