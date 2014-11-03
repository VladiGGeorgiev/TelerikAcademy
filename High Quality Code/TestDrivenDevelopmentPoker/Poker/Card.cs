namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public static string FaceToString(CardFace cardType)
        {
            string cardTypeAsString = null;
            switch (cardType)
            {
                case CardFace.Ace:
                    cardTypeAsString = "A";
                    break;
                case CardFace.King:
                    cardTypeAsString = "K";
                    break;
                case CardFace.Queen:
                    cardTypeAsString = "Q";
                    break;
                case CardFace.Jack:
                    cardTypeAsString = "J";
                    break;
                case CardFace.Ten:
                    cardTypeAsString = "10";
                    break;
                case CardFace.Nine:
                    cardTypeAsString = "9";
                    break;
                case CardFace.Eight:
                    cardTypeAsString = "8";
                    break;
                case CardFace.Seven:
                    cardTypeAsString = "7";
                    break;
                case CardFace.Six:
                    cardTypeAsString = "6";
                    break;
                case CardFace.Five:
                    cardTypeAsString = "5";
                    break;
                case CardFace.Four:
                    cardTypeAsString = "4";
                    break;
                case CardFace.Three:
                    cardTypeAsString = "3";
                    break;
                case CardFace.Two:
                    cardTypeAsString = "2";
                    break;
            }

            return cardTypeAsString;
        }

        public static string SuitToString(CardSuit cardSuit)
        {
            string cardSuitAsString = null;
            switch (cardSuit)
            {
                case CardSuit.Spades:
                    cardSuitAsString = "\u2660";
                    break;
                case CardSuit.Hearts:
                    cardSuitAsString = "\u2665";
                    break;
                case CardSuit.Diamonds:
                    cardSuitAsString = "\u2666";
                    break;
                case CardSuit.Clubs:
                    cardSuitAsString = "\u2663";
                    break;
            }

            return cardSuitAsString;
        }

        public override string ToString()
        {
            var face = FaceToString(this.Face);
            var suit = SuitToString(this.Suit);

            return string.Format("{0}{1}", face, suit);
        }                 
    }                     
}
