using CardDeck;
using ElonVSmarkTask3;

public interface IExperimentService
{
    Task<int> RunExperiment(IDeckShuffler deckShuffler, Deck deck, IPlayer elonPlayer, IPlayer markPlayer);
}