using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace TestPoker
{
    [TestClass]
    public class TestPokerHandsChecker
    {
        private PokerHandsChecker checker = new PokerHandsChecker();

        [TestMethod]
        public void TestIsValidHand()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
            });

            Assert.IsTrue(this.checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsValidHandWithFourCardsHand()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            Assert.IsFalse(this.checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsValidHandWithSixCardsHand()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            Assert.IsFalse(this.checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsValidHandWithSameCards()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
            });

            Assert.IsFalse(this.checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsStraightFlushWithAceToFiveHearts()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
            });

            Assert.IsTrue(this.checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIsStraightFlushWithEightToQueenSpades()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            Assert.IsTrue(this.checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIsStraightFlushWithStraight()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            Assert.IsFalse(this.checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIsFourOfAKindWithFourTens()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
            });

            Assert.IsTrue(this.checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestIsFourOfAKindWithTreeOfAKind()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            });

            Assert.IsFalse(this.checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestIsFullHouseWithFullHouse()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
            });

            Assert.IsTrue(this.checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouseWithTwoPairs()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
            });

            Assert.IsFalse(this.checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFlushWithFlush()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
            });

            Assert.IsTrue(this.checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsFlushWithFourSameSuits()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
            });

            Assert.IsFalse(this.checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsStraightWithStraight()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
            });

            Assert.IsTrue(this.checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraightWithAceToFive()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            Assert.IsTrue(this.checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsThreeOfAKindWithFourOfAKind()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
            });

            Assert.IsFalse(this.checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestIsThreeOfAKindWithThreeOfAKind()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
            });

            Assert.IsTrue(this.checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestIsThreeOfAKindWithFullHouse()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
            });

            Assert.IsFalse(this.checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestIsTwoPairWithTwoPair()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
            });

            Assert.IsTrue(this.checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestIsTwoPairWithFullHouse()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            });

            Assert.IsFalse(this.checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestIsOnePairWithOnePair()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
            });

            Assert.IsTrue(this.checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestIsOnePairWithTwoPair()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Spades),
            });

            Assert.IsFalse(this.checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestIsOnePairWithFullHouse()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Spades),
            });

            Assert.IsFalse(this.checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestIsHighCardWithHighCard()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            Assert.IsTrue(this.checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestIsHighCardWithStraight()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            Assert.IsFalse(this.checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestCompareHandsWithStraightAndStraightFlush()
        {
            Hand firstHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            Hand secondHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            Assert.AreEqual(-1, this.checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestCompareHandsWithFourOfAKindAndFullHouse()
        {
            Hand firstHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            Hand secondHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
            });

            Assert.AreEqual(1, this.checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestCompareHandsWithSameHands()
        {
            Hand firstHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            Hand secondHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Clubs),
            });

            Assert.AreEqual(0, this.checker.CompareHands(firstHand, secondHand));
        }
    }
}
