using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleGame; 

namespace SampleGameTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestPlayerChangeName()
        {
            string name = "Peter";
            Player player = new Player(name, "29437");
            player.ChangeName("Stamat");
            Assert.AreEqual("Stamat", player.Name, string.Format("Change name method is not working!"));
        }

        [TestMethod]
        public void TestPlayerChangeId()
        {
            string id = "17323";
            Player player = new Player("Peter", id);
            player.ChangeID("99999");
            Assert.AreEqual("99999", player.ID, string.Format("Change Id method is not working!"));
        }
    }
}
