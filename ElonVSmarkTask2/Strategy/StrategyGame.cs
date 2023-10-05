using CardDeck;

namespace Strategy
{
    public class GameStrategy : ICardStrategy
    {
        public int SelectCard(Card[] cards)
        {
            int blackCardCount = cards.Count(card => card.Color == CardColor.Black);
            
            double opponentCardNumber = (18 - blackCardCount) / 18.0 * 10;
            int roundedOpponentCardNumber = (int)Math.Round(opponentCardNumber);

            return roundedOpponentCardNumber;

        }
    }
}