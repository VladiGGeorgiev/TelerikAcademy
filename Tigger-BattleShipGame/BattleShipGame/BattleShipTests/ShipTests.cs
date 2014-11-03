using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;
using BattleShip.Common;

namespace BattleShipTests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void CreateShipBodyTest()
        {
            Ship s = new Ship(new Position(0, 0), 3, Alignment.Horizontal);

            Position[] sb = new Position[3]
            {
                new Position(0,0),
                new Position(0,1),
                new Position(0,2),
            };

            Position[] sb1 = s.GetBody() as Position[];
             
            CollectionAssert.AreEqual(sb1, sb);
        }

        [TestMethod]
        public void CreateShipBodyTest2()
        {
            Ship ship = new Ship(new Position(5, 4), 5, Alignment.Vertical);

            Position[] position = new Position[5]
            {
                new Position(5, 4),
                new Position(6, 4),
                new Position(7, 4),
                new Position(8, 4),
                new Position(9, 4),
            };

            Position[] shipPosition = ship.GetBody() as Position[];

            CollectionAssert.AreEqual(shipPosition, position);
        }

        [TestMethod]
        public void CreateShipBodyTest3()
        {
            Ship ship = new Ship(new Position(8, 2), 2, Alignment.Horizontal);

            Position[] position = new Position[2]
            {
                new Position(8, 2),
                new Position(8, 3),
            };

            Position[] shipPosition = ship.GetBody() as Position[];

            CollectionAssert.AreEqual(shipPosition, position);
        }
    }
}
