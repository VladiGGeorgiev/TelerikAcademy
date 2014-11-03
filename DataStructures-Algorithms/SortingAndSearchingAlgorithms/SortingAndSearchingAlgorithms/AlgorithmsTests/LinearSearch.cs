using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace AlgorithmsTests
{
    [TestClass]
    public class LinearSearch
    {
        [TestMethod]
        public void TestLinearSearchIsElementExist()
        {
            var collection = new SortableCollection<int>(new[] { 1, 4, 23, 33, 45, 55, 57, 58, 90 });

            var actual = collection.LinearSearch(45);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestLinearSearchWithNonExistingElement()
        {
            var collection = new SortableCollection<int>(new[] { 1, 4, 23, 33, 45, 55, 57, 58, 90 });

            var actual = collection.LinearSearch(69);

            Assert.IsFalse(actual);
        }
    }
}
