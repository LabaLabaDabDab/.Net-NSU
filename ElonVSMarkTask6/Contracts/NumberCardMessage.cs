namespace Contracts
{
    public record NumberCardMessage
    {
        public int Number { get; init; }
        public string? Player { get; init; }
    }
}
