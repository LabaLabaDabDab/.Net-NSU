using CardDeck;
using ElonVSmarkTask4;
using Strategy;


namespace ElonVSmarkTask4
{
    public class ElonMask : IPlayer
    {
        private readonly ICardStrategy _cardStrategy;

        public ElonMask(ICardStrategy cardStrategy)
        {
            _cardStrategy = cardStrategy;
        }

        public string Name => "Elon Mask";

        public int MakeMove(Card[] cards)
        {
            int chosenCardIndex = _cardStrategy.SelectCard(cards);
            return chosenCardIndex;
        }
    }

    public class MarkZuckerberg : IPlayer
    {
        private readonly ICardStrategy _cardStrategy;

        public MarkZuckerberg(ICardStrategy cardStrategy)
        {
            _cardStrategy = cardStrategy;
        }

        public string Name => "Mark Zuckerberg";

        public int MakeMove(Card[] cards)
        {
            int chosenCardIndex = _cardStrategy.SelectCard(cards);
            return chosenCardIndex;
        }
    }
}
