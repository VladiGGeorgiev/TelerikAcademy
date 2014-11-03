using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace TestPoker
{
    [TestClass]
    public class TestCard
    {
        private string spade = "\u2660";
        private string heart = "\u2665";
        private string diamond = "\u2666";
        private string club = "\u2663";

        [TestMethod]
        public void TestToStringTenOfDiamonds()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string result = "10" + this.diamond;

            Assert.AreEqual(card.ToString(), result);
        }

        [TestMethod]
        public void TestToStringAceOfClubs()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Clubs);
            string result = "A" + this.club;

            Assert.AreEqual(card.ToString(), result);
        }

        [TestMethod]
        public void TestToStringJackOfHearts()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Hearts);
            string result = "J" + this.heart;

            Assert.AreEqual(card.ToString(), result);
        }

        [TestMethod]
        public void TestToStringQueenOfSpades()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Spades);
            string result = "Q" + this.spade;

            Assert.AreEqual(card.ToString(), result);
        }

        [TestMethod]
        public void TestToStringTwoOfDiamonds()
        {
            Card card = new Card(CardFace.Two, CardSuit.Diamonds);
            string result = "2" + this.diamond;

            Assert.AreEqual(card.ToString(), result);
        }
    }
}
