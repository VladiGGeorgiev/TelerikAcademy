using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace TestPoker
{
    [TestClass]
    public class TestHand
    {
        private string spade = "\u2660";
        private string heart = "\u2665";
        private string diamond = "\u2666";
        private string club = "\u2663";

        [TestMethod]
        public void TestToString()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);
            string result = "7" + this.heart + "8" + this.club + "9" + this.heart + "6" + this.spade + "5" + this.diamond;

            Assert.AreEqual(hand.ToString(), result);
        }

        [TestMethod]
        public void TestToStringSampleHand()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);
            string result = "4" + this.spade + "3" + this.club + "K" + this.heart + "10" + this.spade + "J" + this.diamond;

            Assert.AreEqual(hand.ToString(), result);
        }
    }
}
