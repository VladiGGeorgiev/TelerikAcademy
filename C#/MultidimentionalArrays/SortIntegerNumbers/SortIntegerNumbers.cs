using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortIntegerNumbers
{
    class SortIntegerNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Insert n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Insert k: ");
            int k = int.Parse(Console.ReadLine());
            int[] numbers = ReadArray(n);

            Array.Sort(numbers);
            Write(numbers);

            int index = FindLargestElementSmallerThanK(numbers, k);

            Console.WriteLine("Biggest element, smaller or equal to {0} is: {1}", k, numbers[index]);
        }

        private static int FindLargestElementSmallerThanK(int[] array, int k)
        {
            int index = Array.BinarySearch(array, k);
            while (index < 0)
            {
                k--;
                index = Array.BinarySearch(array, k);
            }
            return index;
        }

        private static void Write(int[] number)
        {
            Console.WriteLine(string.Join(", ", number));
        }

        private static int[] ReadArray(int n)
        {
            int[] array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("array[{0}]= ", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }
    }
}
