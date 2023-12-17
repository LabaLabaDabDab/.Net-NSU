using CardDeck;

namespace Strategy
{
    public class GameStrategy : ICardPickStrategy
    {
        public int Pick(Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].Color == CardColor.Red)
                {
                    return i; // Возвращаем индекс первой красной карты
                }
            }

            return cards.Length - 1; // Если нет красных карт, возвращаем индекс последней карты
        }
    }
}