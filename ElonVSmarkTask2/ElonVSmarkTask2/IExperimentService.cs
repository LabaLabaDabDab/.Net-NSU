using CardDeck;
using ElonVSmarkTask2;

public interface IExperimentService
{
    Task<int> RunExperiment(IDeckShuffler deckShuffler, Deck deck, IPlayer elonPlayer, IPlayer markPlayer);
}