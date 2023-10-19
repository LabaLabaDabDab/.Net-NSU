using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;

namespace CardDeck
{
    public enum CardColor
    {
        Red,
        Black
    }

    public class Card
    {
        public int Number { get; set; }
        public CardColor Color { get; set; }

        public Card(int number, CardColor color)
        {
            Number = number;
            Color = color;
        }

        public override string ToString() => $"{Number} of {Color}";
    }

    public class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            for (int i = 0; i < 36; i++)
            {
                CardColor color = (i < 18) ? CardColor.Red : CardColor.Black;
                cards.Add(new Card(i, color));
            }
        }
    }

    
}
