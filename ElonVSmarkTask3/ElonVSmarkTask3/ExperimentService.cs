using CardDeck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonVSmarkTask3
{

    public class ExperimentService : IExperimentService
    {
        public async Task<int> RunExperiment(IDeckShuffler deckShuffler, Deck deck, IPlayer elonPlayer, IPlayer markPlayer)
        {
            int successes = 0;

            var shuffledDeck = deckShuffler.ShuffleDeck(deck.cards);

            Card[] elonCards = shuffledDeck.Take(18).ToArray();
            Card[] markCards = shuffledDeck.Skip(18).ToArray();

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
