namespace Poker
{
    using System;
    using System.Collections.Generic;
    class PokerExample
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            IHand hand2 = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
            });

            Console.WriteLine(hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine("Is valid hand: " + checker.IsValidHand(hand));
            Console.WriteLine("Is one pair: " + checker.IsOnePair(hand));
            Console.WriteLine("Is two pairs: " + checker.IsTwoPair(hand));

            Console.WriteLine(Environment.NewLine + "Compare hands. 1 for first hand. -1 for second hand. 0 for same hands");
            Console.WriteLine("Hand: {0}, Hand2: {1} Compare: {2}", hand, hand2, checker.CompareHands(hand, hand2));
        }
    }
}
