using CardDeck;

namespace ElonVSmarkTask4
{
    public class ExperimentService : IExperimentService
    {
        public async Task<int> RunExperiment(IDeckShuffler deckShuffler, Deck deck, IPlayer elonPlayer, IPlayer markPlayer)
        {
            int successes = 0;

            if (deckShuffler != null)
            {
                deck.cards = deckShuffler.ShuffleDeck(deck.cards);
            }

            Card[] elonCards = deck.cards.Take(18).ToArray();
            
            Card[] markCards = deck.cards.Skip(18).ToArray();
            int elonChoice = elonPlayer.MakeMove(elonCards);
            int markChoice = markPlayer.MakeMove(markCards);

            if (markCards[elonChoice].Color == elonCards[markChoice].Color)
            {
                successes++;
            }

            return successes;
        }
    }
}
