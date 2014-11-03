using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;
using BattleShip.Common;

namespace BattleShipTests
{
    [TestClass]
    public class SeaTest
    {
        [TestMethod]
        public  void GetBodyTest()
        {
           State[,] testSea = new State[10, 10];

           for (int row = 0; row < testSea.GetLength(0); row++)
            {
                for (int col = 0; col < testSea.GetLength(1); col++)
                {
                    testSea[row, col] = State.Empty;
                }
            }

            BootSea sea = new BootSea(testSea.GetLength(0), testSea.GetLength(1));
            
            CollectionAssert.AreEqual(sea.GetBody(), testSea);
        }

        [TestMethod]
        public void GetBodyTest2()
        {
            State[,] testSea = new State[20, 20];

            for (int row = 0; row < testSea.GetLength(0); row++)
            {
                for (int col = 0; col < testSea.GetLength(1); col++)
                {
                    testSea[row, col] = State.Empty;
                }
            }

            BootSea sea = new BootSea(testSea.GetLength(0), testSea.GetLength(1));

            CollectionAssert.AreEqual(sea.GetBody(), testSea);
        }

        [TestMethod]
        public void GetBodyTest3()
        {
            State[,] testSea = new State[5, 20];

            for (int row = 0; row < testSea.GetLength(0); row++)
            {
                for (int col = 0; col < testSea.GetLength(1); col++)
                {
                    testSea[row, col] = State.Empty;
                }
            }

            BootSea sea = new BootSea(testSea.GetLength(0), testSea.GetLength(1));

            CollectionAssert.AreEqual(sea.GetBody(), testSea);
        }
    }
}
