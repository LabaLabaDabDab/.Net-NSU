using CardDeck;

namespace Contracts
{
    public record CardMessage
    {
        public List<Card> Cards { get; init; }
    }
}
