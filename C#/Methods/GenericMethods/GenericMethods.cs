/** Modify your last program and try to make it work for any number type, 
 * not just integer (e.g. decimal, float, byte, etc.). Use generic method
 * (read in Internet about generic methods in C#).
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethods
{
    class GenericMethods
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

        private static long Minimum(params long[] array)
        {
            long minElement = long.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (minElement > array[i])
                {
                    minElement = array[i];
                }
            }

            return minElement;
        }

        private static short Minimum(params short[] array)
        {
            short minElement = short.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (minElement > array[i])
                {
                    minElement = array[i];
                }
            }

            return minElement;
        }

        private static byte Minimum(params byte[] array)
        {
            byte minElement = byte.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (minElement > array[i])
                {
                    minElement = array[i];
                }
            }

            return minElement;
        }

        private static double Minimum(params double[] array)
        {
            double minElement = double.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (minElement > array[i])
                {
                    minElement = array[i];
                }
            }

            return minElement;
        }

        private static decimal Minimum(params decimal[] array)
        {
            decimal minElement = decimal.MaxValue;
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

        private static byte Maximum(params byte[] array)
        {
            byte maxElement = byte.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (maxElement < array[i])
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }

        private static short Maximum(params short[] array)
        {
            short maxElement = short.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (maxElement < array[i])
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }

        private static long Maximum(params long[] array)
        {
            long maxElement = long.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (maxElement < array[i])
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }

        private static double Maximum(params double[] array)
        {
            double maxElement = double.MinValue;
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

        private static long Sum(params int[] array)
        {
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        private static short Sum(params sbyte[] array)
        {
            short sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        private static int Sum(params short[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        private static double Sum(params double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
