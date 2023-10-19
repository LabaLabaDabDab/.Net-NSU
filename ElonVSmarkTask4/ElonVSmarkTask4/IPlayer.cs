using CardDeck;
using Strategy;

namespace ElonVSmarkTask4
{
    public interface IPlayer
    {
        public string Name { get; }
        int MakeMove(Card[] cards);
    }
}
