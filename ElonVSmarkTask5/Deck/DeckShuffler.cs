using CardDeck;

public class DeckShuffler : IDeckShuffler
{
    public List<Card> ShuffleDeck(List<Card> deck)
    {
        Random random = new Random();
        List<Card> shuffleCards = new List<Card>(deck);
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
