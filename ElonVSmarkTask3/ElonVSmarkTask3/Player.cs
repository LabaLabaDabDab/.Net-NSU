using CardDeck;
using ElonVSmarkTask3;
using Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonVSmarkTask3
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
