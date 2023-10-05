using CardDeck;

namespace Strategy
{
    public interface ICardStrategy
    {
        int SelectCard(Card[] cards);
    }
}
