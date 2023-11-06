﻿using Contracts;
using ElonWeb;
using MassTransit;
using Strategy;

namespace Consumers
{
    public class DeckConsumer : IConsumer<CardMessage>
    {
        public Task Consume(ConsumeContext<CardMessage> context)
        {
            var cards = context.Message.Cards;
            ElonDeck.Cards = cards;
            ICardStrategy elonStrategy = new GameStrategy();
            int elonChoice = elonStrategy.SelectCard(cards.ToArray());

            context.Publish(new NumberCardMessage
            {
                Number = elonChoice,
                Player = "Elon"
            });

            return Task.CompletedTask;
        }    
    }
}