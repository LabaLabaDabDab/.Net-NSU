using CardDeck;
using Strategy;

public class ExperimentService : IExperimentService
{
    public Task<int> RunExperiment(IDeckShuffler deckShuffler, Deck deck)
    {
        int successes = 0;

        var shuffledDeck = deckShuffler.ShuffleDeck(deck.cards);

        Card[] elonCards = shuffledDeck.Take(18).ToArray();
        Card[] markCards = shuffledDeck.Skip(18).ToArray();

        ICardStrategy strategy = new GameStrategy();

        int elonChoice = strategy.SelectCard(elonCards);
        int markChoice = strategy.SelectCard(markCards);

        if (markCards[elonChoice].Color == elonCards[markChoice].Color)
        {
            successes++;
        }
        

        return Task.FromResult(successes);
    }
}
