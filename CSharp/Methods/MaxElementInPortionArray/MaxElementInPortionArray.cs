/*Write a method that return the maximal element in a portion of array
 * of integers starting at given index. Using it write another method 
 * that sorts an array in ascending / descending order.
*/
namespace MaxElementInPortionArray
{
    using System;
    using System.Linq;

    public class MaxElementInPortionArray
    {
        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        private static int MaxElement(int[] array, int startIndex)
        {
            int maxElement = int.MinValue;
            for (int i = startIndex; i < array.Length; i++)
            {
                if (maxElement < array[i])
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }

        private static void Main()
        {
            int[] array = { 1, 4, 6, 7, 34, 53, 45, 34, 2, 12, 23, 42 };
            int startIndex = 8;
            Print(array);
            Console.WriteLine(MaxElement(array, startIndex));

            Array.Sort(array);
            Print(array);
            Print(Reverse(array));
        }

        private static int[] Reverse(int[] array)
        {
            int[] reversedArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                reversedArray[i] = array[(array.Length - 1) - i];
            }

            return reversedArray;
        }
    }
}
