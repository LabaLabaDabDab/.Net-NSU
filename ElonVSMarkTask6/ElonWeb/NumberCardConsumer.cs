using Common;
using Contracts;
using MassTransit;

namespace ElonWeb
{
    public class NumberCardConsumer : IConsumer<NumberCardMessage>
    {
        public Task Consume(ConsumeContext<NumberCardMessage> context)
        {
            if (context.Message.Player == "Mark")
            {
                ElonDeck.Color = ElonDeck.Cards[context.Message.Number].Color;
                ResourceLockManager.ResourceAvailable();
            }

            return Task.CompletedTask;
        }
    }
}