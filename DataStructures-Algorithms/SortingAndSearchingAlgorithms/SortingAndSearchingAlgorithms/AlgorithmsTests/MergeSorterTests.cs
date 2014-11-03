using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SortingSearchingAlgo;

namespace AlgorithmsTests
{
    [TestClass]
    public class MergeSorterTests
    {
        [TestMethod]
        public void TestSortLengthOfCollection()
        {
            List<int> collection = new List<int>()
            {
                3, 5, 21, 543, 2, 12, 3, 65, 34, 234, 23, 12, 3, 43, 12, 32, 341, 24, 23 
            };
            int count = collection.Count;
            MergeSorter<int> sorter = new MergeSorter<int>();
            sorter.Sort(collection);

            Assert.AreEqual(count, collection.Count);
        }

        [TestMethod]
        public void TestSortIsSortedWithListSort()
        {
            List<int> collection = new List<int>()
            {
                3, 5, 21, 543, 2, 12, 3, 65, 34, 234, 23, 12, 3, 43, 12, 32, 341, 24, 23 
            };
            MergeSorter<int> sorter = new MergeSorter<int>();
            sorter.Sort(collection);

            List<int> collection2 = new List<int>()
            {
                3, 5, 21, 543, 2, 12, 3, 65, 34, 234, 23, 12, 3, 43, 12, 32, 341, 24, 23 
            };
            collection2.Sort();

            CollectionAssert.AreEqual(collection2, collection);
        }

        [TestMethod]
        public void TestSortIsSortedWithCheck()
        {
            List<int> collection = new List<int>()
            {
                3, 5, 21, 543, 2, 12, 3, 65, 34, 234, 23, 12, 3, 43, 12, 32, 341, 24, 23 
            };
            MergeSorter<int> sorter = new MergeSorter<int>();
            sorter.Sort(collection);

            bool isSorted = true;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                if (collection[i] > collection[i + 1])
                {
                    isSorted = false;
                }
            }

            Assert.IsTrue(isSorted);
        }
    }
}
