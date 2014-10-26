/*Write methods to calculate minimum, maximum, average, sum and product 
 * of given set of integer numbers. Use variable number of arguments.
*/
namespace OperationsOfIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OperationsOfIntegers
    {
        public static void Main()
        {
            Console.WriteLine("Min element of 2, 4, 5, 1, 7, 9 is: {0}", Minimum(2, 4, 5, 1, 7, 9));
            Console.WriteLine("Max element of 2, 3, 5, 6, 7, 8, 9, 5, 34 is: {0}", Maximum(2, 3, 5, 6, 7, 8, 9, 5, 34));
            Console.WriteLine("Average of 5, 56, 16, 56 is: {0}", Average(5, 56, 16, 56));
            Console.WriteLine("Sum of 1515, 16516, 51651 is: {0}", Sum(1515, 16516, 51651));
        }

        private static int Minimum(params int[] array)
        {
            int minElement = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (minElement > array[i])
                {
                    minElement = array[i];
                }
            }

            return minElement;
        }

        private static int Maximum(params int[] array)
        {
            int maxElement = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (maxElement < array[i])
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }

        private static double Average(params int[] array)
        {
            int sum = 0;
            double average = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            average = (double)sum / array.Length;
            return average;
        }

        private static int Sum(params int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
