using Deck;
using Strategy;

namespace ElonVSmark
{
    class CardGame
    {
        static void Main()
        {
            const int totalExperiments = 1000000;
            int totalSuccesses = 0;

            var deck = new Deck.Deck();

            Card[] elonCards;
            Card[] markCards;                        

            for (int i = 0; i < totalExperiments; i++)
            {
                var shuffledDeck = deck.GetShuffleDeck();

                elonCards = shuffledDeck.Take(18).ToArray();
                markCards = shuffledDeck.Skip(18).ToArray();

                ICardStrategy strategy = new GameStrategy();

                int elonChoice = strategy.SelectCard(elonCards);
                int markChoice = strategy.SelectCard(markCards);

                if (markCards[elonChoice].Color == elonCards[markChoice].Color)
                {
                    totalSuccesses++;                  
                }
            }

            double successRate = ((double)totalSuccesses / totalExperiments) * 100;
            Console.Write("Процент успешных боёв: " + successRate + "%");
        }
    }
}