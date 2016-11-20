namespace SkeletonCode.CardGame
{
    public enum CardSuit
    {
        Clubs, Spades, Hearts, Diamonds
    }

    public class Card : ICard
    {
        public Card(CardSuit suit, string value)
        {
            Suit = suit;
            CardValue = value;
        }

        public CardSuit Suit { get; private set; }

        public string CardValue { get; private set; }
    };
}