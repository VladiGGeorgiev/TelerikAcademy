using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableMethods
{
    public static class IEnumerableMethods
    {
        public static T Sum<T>(this IEnumerable<T> list) where T : IEnumerable
        {
            dynamic sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> list) where T : IEnumerable
        {
            dynamic product = 1;
            foreach (var item in list)
            {
                product *= item;
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> list) where T : IEnumerable
        {
            dynamic minElement = int.MaxValue;
            foreach (var item in list)
            {
                if (item < minElement)
                {
                    minElement = item;
                }
            }

            return minElement;
        }

        public static T Max<T>(this IEnumerable<T> list) where T : IEnumerable
        {
            dynamic maxElement = int.MinValue;
            foreach (var item in list)
            {
                if (item > maxElement)
                {
                    maxElement = item;
                }
            }

            return maxElement;
        }

        public static double Average<T>(this IEnumerable<T> list) where T : IEnumerable
        {
            dynamic sum = list.Sum();
            double average = (double)sum / list.Count();

            return average;
        }
    }
}
