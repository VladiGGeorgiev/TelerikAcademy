using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateVariations
{
    class GenerateVariations
    {
        static string[] elements;
        static string[] current;
        static const int K = 2;
        static const int N = 3;

        public static void Main()
        {
            elements = new string[] { "hi", "a", "b"};
            current = new string[N];
            FindVariations(0);
        }

        private static void FindVariations(int index)
        {
            if (index == K)
            {
                Console.WriteLine(string.Join(" ", current));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                current[index] = elements[i];
                FindVariations(index + 1);
            }
        }
    }
}
