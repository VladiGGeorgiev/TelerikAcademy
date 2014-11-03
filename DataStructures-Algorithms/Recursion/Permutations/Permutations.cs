using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Permutations
    {
        static bool[] usedNumbers;
        static int[] currentpermutation;

        public static void Main()
        {
            int n = 3;
            currentpermutation = new int[n];
            usedNumbers = new bool[n + 1];

            FindPermutations(0);
        }

        private static void FindPermutations(int index)
        {
            if (index == currentpermutation.Length)
            {
                Console.WriteLine(string.Join(" ", currentpermutation));
                return;
            }

            for (int num = 1; num <= currentpermutation.Length; num++)
            {
                if (!usedNumbers[num])
                {
                    currentpermutation[index] = num;
                    usedNumbers[num] = true;
                    FindPermutations(index + 1);
                    usedNumbers[num] = false;
                }
            }
        }
    }
}
