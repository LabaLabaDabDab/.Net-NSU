using Contracts;
using MarkWeb;
using MassTransit;
using Strategy;

namespace Consumers
{
    public class DeckConsumer : IConsumer<CardMessage>
    {
        public Task Consume(ConsumeContext<CardMessage> context)
        {
            var cards = context.Message.Cards;
            MarkDeck.Cards = cards;
            ICardStrategy markStrategy = new GameStrategy();
            int markChoice = markStrategy.SelectCard(cards.ToArray());
            
            context.Publish(new NumberCardMessage
            {
                Number = markChoice,
                Player = "Mark"
            });

            return Task.CompletedTask;
        }
    }
}