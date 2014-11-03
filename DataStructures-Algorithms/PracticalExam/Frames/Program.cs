using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames
{
    class Program
    {
        static List<int> set = new List<int>() { 1, 3, 5, 5 };
        static bool[] usedNumbers;
        static int[] currentPermutation;
        static List<List<int>> results = new List<List<int>>();
        static List<int> numbers = new List<int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');

                for (int j = 0; j < line.Length; j++)
                {
                    numbers.Add(int.Parse(line[j]));
                }
            }

            currentPermutation = new int[n * 2]; 
            usedNumbers = new bool[n * 2];

            FindPermutations(0);
        }

        private static void FindPermutations(int index)
        {
            if (index == currentPermutation.Length)
            {
                for (int i = 0; i < currentPermutation.Length; i++)
                {
                    currentPermutation[i] = numbers[currentPermutation[i]];
                }

                if (!CheckExist(results, currentPermutation))
                {
                    results.Add(currentPermutation.ToList());
                }

                return;
            }

            for (int i = 0; i < currentPermutation.Length; i++)
            {
                if (!usedNumbers[i])
                {
                    currentPermutation[index] = i;
                    usedNumbers[i] = true;
                    FindPermutations(index + 1);
                    usedNumbers[i] = false;
                }
            }
        }

        public static bool CheckExist(List<List<int>> results, int[] current)
        {
            if (results.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < results.Count; i++)
            {
                bool isExist = true;
                for (int j = 0; j < results[i].Count; j++)
                {
                    if (results[i][j] != current[j])
                    {
                        isExist = false;
                    }
                }

                if (isExist)
                {
                    return isExist;
                }
            }

            return false;
        }
    }
}
