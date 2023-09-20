namespace Deck
{
    public enum CardColor
    {
        Red,
        Black
    }

    public class Card
    {
        public int Number { get; }
        public CardColor Color { get; }

        public Card(int number, CardColor color)
        {
            Number = number;
            Color = color;
        }
    }

    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            for (int i = 0; i < 36; i++)
            {
                CardColor color = (i < 18) ? CardColor.Red : CardColor.Black;
                cards.Add(new Card(i, color));
            }
        }

        public List<Card> GetShuffleDeck(Random random)
        {
            List<Card> shuffleCards = new List<Card>(cards);
            int n = shuffleCards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (shuffleCards[k], shuffleCards[n]) = (shuffleCards[n], shuffleCards[k]);
            }
            return shuffleCards;
        }
    }
}