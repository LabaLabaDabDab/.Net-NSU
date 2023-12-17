using CardDeck;

namespace Strategy
{
    public interface ICardPickStrategy
    {
        int Pick(Card[] cards);
    }
}