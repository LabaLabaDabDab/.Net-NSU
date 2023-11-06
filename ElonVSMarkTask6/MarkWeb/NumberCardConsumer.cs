using Common;
using Contracts;
using MassTransit;

namespace MarkWeb
{
    public class NumberCardConsumer : IConsumer<NumberCardMessage>
    {
        public Task Consume(ConsumeContext<NumberCardMessage> context)
        {
            if (context.Message.Player == "Elon")
            {
                MarkDeck.Color = MarkDeck.Cards[context.Message.Number].Color;
                ResourceLockManager.ResourceAvailable();
            }

            return Task.CompletedTask;
        }
    }
}