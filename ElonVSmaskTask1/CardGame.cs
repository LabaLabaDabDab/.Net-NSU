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

            Random random = new Random();
            var deck = new Deck.Deck();

            Card[] elonCards;
            Card[] markCards;
                        

            for (int i = 0; i < totalExperiments; i++)
            {
                var shuffledDeck = deck.GetShuffleDeck(random);
                elonCards = shuffledDeck.Take(18).ToArray();
                markCards = shuffledDeck.Skip(18).ToArray();

                //Console.WriteLine("Илон Маск:");
                //foreach (var card in elonCards)
                //{
                //    Console.WriteLine($"Карта {card.Number}, Цвет: {card.Color}");
                //}

                //Console.WriteLine("Марк Цукерберг:");
                //foreach (var card in markCards)
                //{
                //    Console.WriteLine($"Карта {card.Number}, Цвет: {card.Color}");
                //}

                ICardStrategy strategy = new GameStrategy();

                int elonChoice = strategy.SelectCard(elonCards);

                int markChoice = strategy.SelectCard(markCards);

                //Console.WriteLine("Карта, которую выбрал Илон: " + elonChoice);
                //Console.WriteLine("Карта, которую выбрал Марк: " + markChoice);

                //bool colorsMatch = markCards[elonChoice].Color == elonCards[markChoice].Color;
                //Console.WriteLine(colorsMatch);
                //Console.WriteLine(markCards[elonChoice].Color + " VS " + elonCards[markChoice].Color);

                if (markCards[elonChoice].Color == elonCards[markChoice].Color)
                {
                    totalSuccesses++;                  
                }
            }

            double successRate = ((double)totalSuccesses / totalExperiments) * 100;
            Console.Write("Процент успешных боёв: " + successRate + "%");
        }
        static bool CheckColorMatch(Card markDeck, Card elonDeck)
        {
            return markDeck.Color == elonDeck.Color;
        }
    }
}