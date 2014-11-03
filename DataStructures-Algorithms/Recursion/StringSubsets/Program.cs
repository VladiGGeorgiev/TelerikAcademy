using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSubsets
{
    class Program
    {
        static string[] elements = new string[] { "test", "rock", "fun" };
        const int K = 2;
        static int[] currentSubset = new int[K];

        static void Main(string[] args)
        {

            FindSubsets(0);
        }

        private static void FindSubsets(int index)
        {
            if (index == K)
            {
                Print(currentSubset);
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (index != 0 && currentSubset[index - 1] <= i)
                {
		            continue;
                }

                currentSubset[index] = i;
                FindSubsets(index + 1);
            }
        }

        private static void Print(int[] currentSubset)
        {
            for (int i = currentSubset.Length - 1; i >= 0; i--)
            {
                Console.Write(elements[currentSubset[i]] + " ");
            }
            Console.WriteLine();
        }
    }
}
