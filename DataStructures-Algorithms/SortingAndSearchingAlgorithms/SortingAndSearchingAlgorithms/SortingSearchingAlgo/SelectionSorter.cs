namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int minElementIndex;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                minElementIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[minElementIndex].CompareTo(collection[j]) > 0)
                    {
                        minElementIndex = j;
                    }
                }

                if (collection[minElementIndex].CompareTo(collection[i]) != 0)
                {
                    T temp = collection[i];
                    collection[i] = collection[minElementIndex];
                    collection[minElementIndex] = temp;
                }
            }
        }
    }
}
