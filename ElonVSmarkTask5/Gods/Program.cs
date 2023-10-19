using CardDeck;
using System.Text;
using System.Text.Json;

namespace Gods
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int elonPort = 5001;
            int markPort = 5002;
            var deck = new CardDeck.Deck();
            IDeckShuffler shuffler = new DeckShuffler();

            var shuffledDeck = shuffler.ShuffleDeck(deck.cards);

            Card[] elonCards = shuffledDeck.Take(18).ToArray();
            Card[] markCards = shuffledDeck.Skip(18).ToArray();

            var elonChoice = await SendDeckAsync(elonCards, elonPort);
            var markChoice = await SendDeckAsync(markCards, markPort);

            Console.WriteLine($"Elon's choice: {elonChoice} - {markCards[elonChoice]}");
            Console.WriteLine($"Mark's choice: {markChoice} - {elonCards[markChoice]}");

            if (markCards[elonChoice].Color == elonCards[markChoice].Color)
            {
                Console.WriteLine("Winner Winner chicken dinner");
            }
            else
            {
                Console.WriteLine("We were forbidden to fight(...");
            }
        }

        private static async Task<int> SendDeckAsync(Card[] cards, int port)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(cards);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                using HttpResponseMessage response = await client.PostAsync($"http://localhost:{port}/game/getchoice", content);

                response.EnsureSuccessStatusCode();

                int responseBody = Convert.ToInt32(await response.Content.ReadAsStringAsync());
                return responseBody;
            }
        }

    }
}