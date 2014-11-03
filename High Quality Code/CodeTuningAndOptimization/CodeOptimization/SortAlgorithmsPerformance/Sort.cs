using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithmsPerformance
{
    public static class Sort
    {

        public static void Selection<T>(T[] items) where T : IComparable
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < items.Length; j++)
                {
                    if (items[j].CompareTo(items[min]) < 0) min = j;
                }

                T temp = items[i];
                items[i] = items[min];
                items[min] = temp;
            }
        }

        public static void QuickSort<T>(T[] elements) where T: IComparable
        {
            QuickSort(elements, 0, elements.Length - 1);
        }

        private static void QuickSort<T>(T[] items, int left, int right) where T: IComparable
        {
            int i, j;
            T x, temp;

            i = left;
            j = right;
            x = items[(left + right) / 2];

            do
            {
                while (items[i].CompareTo(x) < 0 && i < right)
                {
                    i++;
                }

                while (items[j].CompareTo(x) > 0 && j > left)
                {
                    j--;
                }

                if (i <= j)
                {
                    temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);


            if (left < j)
            {
                QuickSort(items, left, j);
            }
            if (i < right)
            {
                QuickSort(items, i, right);
            }
        }


        public static void InsertionSort<T>(T[] items) where T : IComparable
        {
            T temp;
            int k;

            for (int i = 1; i < items.Length; i++)
            {
                temp = items[i];
                k = i - 1;
                while (k >= 0 && items[k].CompareTo(temp) > 0)
                {
                    items[k + 1] = items[k];
                    k--;
                }

                items[k + 1] = temp;
            }
        }
    }
}
