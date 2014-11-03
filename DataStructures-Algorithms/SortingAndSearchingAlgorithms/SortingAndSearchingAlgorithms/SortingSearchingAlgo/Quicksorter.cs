namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var tempCollection = this.QuickSort(collection);
            collection.Clear();

            foreach (var item in tempCollection)
            {
                collection.Add(item);
            }
        }

        private IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            //Select and remove pivot from collection
            int randomIndex = new Random().Next(0, collection.Count);
            T pivot = collection[randomIndex];
            collection.RemoveAt(randomIndex);

            IList<T> smallerElements = new List<T>();
            IList<T> biggerElements = new List<T>();
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].CompareTo(pivot) > 0)
                {
                    biggerElements.Add(collection[i]);
                }
                else
                {
                    smallerElements.Add(collection[i]);
                }
            }
            var mergedElements = new List<T>();
            mergedElements.AddRange(QuickSort(smallerElements));
            mergedElements.Add(pivot);
            mergedElements.AddRange(QuickSort(biggerElements));
            //var mergedElements = MergeElements(QuickSort(smallerElements), pivot, QuickSort(biggerElements));
            return mergedElements;
        }
    }
}
