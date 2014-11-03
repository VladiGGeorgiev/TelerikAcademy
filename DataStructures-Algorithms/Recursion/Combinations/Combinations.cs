using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations
{
    class Combinations
    {
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int n = 3;
            int k = 2;
            int[] current = new int[k];

            PrintCombinations(0, n, current);
            Console.WriteLine(sb);
        }

        private static void PrintCombinations(int index, int n, int[] currentCombination)
        {
            if (index == currentCombination.Length)
            {
                sb.AppendLine(string.Join(" ", currentCombination));
                return;
            }

            for (int num = 1; num <= n; num++)
            {
                if (index != 0 && num <= currentCombination[index - 1])
                {
                    continue;
                }

                currentCombination[index] = num;
                PrintCombinations(index + 1, n, currentCombination);
            }
        }
    }
}
