using CardDeck;

public interface IExperimentService
{
    Task<int> RunExperiment(IDeckShuffler deckShuffler, Deck deck);
}