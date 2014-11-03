using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestName()
        {
            string name = "Peter Slavchev";
            int id = 92921;
            Student pesho = new Student(name, id);

            Assert.AreEqual(pesho.Name, name);
        }

        [TestMethod]
        public void TestUniqueId()
        {
            string name = "Minka";
            int id = 75649;

            Student pesho = new Student(name, id);

            Assert.AreEqual(pesho.UniqueNumber, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestEmptyInputName()
        {
            string name = string.Empty;
            Student gosho = new Student(name, 38942);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUniqueIdOutOfRange()
        {
            string name = "Ivan";
            int id = 99999999;
            Student ivan = new Student(name, id);
        }
    }
}
