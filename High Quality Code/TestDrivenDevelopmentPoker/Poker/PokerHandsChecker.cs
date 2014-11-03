namespace Poker
{
    using System;
    using System.Linq;

    /// <summary>
    ///     Checks poker hand power.
    /// </summary>
    public class PokerHandsChecker : IPokerHandsChecker
    {  
        /// <summary>
        ///     Checks if hand is with exactly 5 cards and isn't there same cards.
        /// </summary>
        /// <returns>True or false if hand is valid</returns>
        public bool IsValidHand(IHand hand)
        {
            bool isValidHand = true;
            if (hand.Cards.Count != 5)
            {
                isValidHand = false;
            }

            int count = 
                hand.Cards.Select(x => new { x.Face, x.Suit }).Distinct().Count();

            if (count != 5)
            {
                isValidHand = false;
            }

            return isValidHand;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand is invalid!");
            }

            bool isStraightFlush = this.IsStraight(hand) && this.IsFlush(hand);
            return isStraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            bool isFourOfAKind = false;
            if (!this.IsValidHand(hand))
	        {
                throw new ArgumentException("The hand is invalid!");
	        }

            isFourOfAKind = hand.Cards.GroupBy(x => x.Face).Any(x => x.Count() == 4);
            
            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            bool isFulHouse = false;
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand is invalid!");
            }

            var threeOfAKind = hand.Cards.GroupBy(x => x.Face).Any(x => x.Count() == 3);
            var twoOfAKind = hand.Cards.GroupBy(x => x.Face).Any(x => x.Count() == 2);

            isFulHouse = threeOfAKind && twoOfAKind;
            return isFulHouse;
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand is not valid!");
            }

            bool isFlush = false;

            isFlush = hand.Cards.GroupBy(x => x.Suit).Count() == 1;
            
            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand is not valid!");
            }

            bool isStraight = false;
            var sortedStraight = hand.Cards.OrderBy(x => (int)x.Face).ToList();
            if ((int)sortedStraight[4].Face - (int)sortedStraight[0].Face == 4)
            {
                isStraight = true;
            }

            bool specialCaseWithAceToFive =
                (int)sortedStraight[0].Face == 2 &&
                (int)sortedStraight[1].Face == 3 &&
                (int)sortedStraight[2].Face == 4 &&
                (int)sortedStraight[3].Face == 5 &&
                (int)sortedStraight[4].Face == 14;

            if (specialCaseWithAceToFive)
            {
                isStraight = true;
            }
            
            return isStraight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand is not valid!");
            }

            bool isThreeOfAKind = false;

            var cardGroups = hand.Cards.GroupBy(x => x.Face);
            if (cardGroups.Count() == 3)
            {
                isThreeOfAKind = cardGroups.Any(x => x.Count() == 3);
            }

            return isThreeOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand is invalid!");
            }

            bool isTwoPairs = false;

            var cardGroups = hand.Cards.GroupBy(x => x.Face);
            if (cardGroups.Count() == 3)
            {
                isTwoPairs = cardGroups.Any(x => x.Count() == 2);
            }

            return isTwoPairs;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand is invalid!");
            }

            var cardGroups = hand.Cards.GroupBy(x => x.Face);
            bool isOnePair = false;
            if (cardGroups.Count() == 4)
            {
                isOnePair = cardGroups.Any(x => x.Count() == 2);
            }

            return isOnePair;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("The hand is invalid!");
            }

            bool isDifferentCards = hand.Cards.GroupBy(x => x.Face).Count() == 5;
            bool isDifferentSuits = !this.IsFlush(hand);
            bool isNotStraight = !this.IsStraight(hand);

            return isDifferentCards && isDifferentSuits && isNotStraight;
        }
        
        /// <summary>
        ///     Compare two hands with different power.
        /// </summary>
        /// <returns>If first hand is more powerfull returns 1, else returns -1. If cards is with the same power returns 0</returns>
        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            PokerHandCategory firstHandCategory = this.CategorizePokerHand(firstHand);
            PokerHandCategory secondHandCategory = this.CategorizePokerHand(secondHand);

            if ((int)firstHandCategory < (int)secondHandCategory)
            {
                return 1;
            }
            else if ((int)firstHandCategory > (int)secondHandCategory)
            {
                return -1;
            }
            else
            {
                return 0;
            }

            //TODO: Implement logic for comparing hands with same hand category.
        }

        private PokerHandCategory CategorizePokerHand(IHand hand)
        {
            PokerHandCategory category;
            if (this.IsStraightFlush(hand))
            {
                category = PokerHandCategory.StraightFlush;
            }
            else if (this.IsFourOfAKind(hand))
            {
                category = PokerHandCategory.FourOfAKind;
            }
            else if (this.IsFullHouse(hand))
            {
                category = PokerHandCategory.FullHouse;
            }
            else if (this.IsFlush(hand))
            {
                category = PokerHandCategory.Flush;
            }
            else if (this.IsStraight(hand))
            {
                category = PokerHandCategory.Straight;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                category = PokerHandCategory.ThreeOfAKind;
            }
            else if (this.IsTwoPair(hand))
            {
                category = PokerHandCategory.TwoPairs;
            }
            else if (this.IsOnePair(hand))
            {
                category = PokerHandCategory.OnePair;
            }
            else if (this.IsHighCard(hand))
            {
                category = PokerHandCategory.HighCard;
            }
            else
            {
                throw new ArgumentException("Hand is undefined category!");
            }

            return category;
        }
    }
}
