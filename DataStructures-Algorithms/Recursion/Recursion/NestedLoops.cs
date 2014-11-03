using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class NestedLoops
    {
        static int[] current;
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int n = 4;
            current = new int[n];

            NestedLoops(0);
            Console.WriteLine(sb);
        }

        private static void NestedLoops(int index)
        {
            if (index == current.Length)
            {
                sb.AppendLine(string.Join(" ", current));
                return;
            }

            for (int i = 1; i <= current.Length; i++)
            {
                current[index] = i;
                NestedLoops(index + 1);
            }
        }
    }
}
