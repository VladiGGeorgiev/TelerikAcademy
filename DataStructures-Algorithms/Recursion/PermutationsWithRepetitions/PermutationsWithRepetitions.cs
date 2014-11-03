using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationsWithRepetitions
{
    class PermutationsWithRepetitions
    {
        static List<int> set = new List<int>() { 1, 3, 5, 5 };
        static bool[] usedNumbers;
        static int[] currentPermutation;

        static void Main(string[] args)
        {
            currentPermutation = new int[set.Count];
            usedNumbers = new bool[set.Count];

            FindPermutations(0);
        }

        private static void FindPermutations(int index)
        {
            if (index == currentPermutation.Length)
            {
                PrintPermutation();
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

        private static void PrintPermutation()
        {
            for (int i = 0; i < currentPermutation.Length; i++)
            {
                Console.Write(set[currentPermutation[i]]);
            }
            Console.WriteLine();
        }
    }
}
