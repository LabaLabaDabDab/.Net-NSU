using CardDeck;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests;

[TestFixture]
public class DeckTests
{
    [Test]
    public void Deck_ShouldHave18BlackAnd18RedCards()
    {
        var deck = new Deck();
        int blackCardsCount = deck.cards.Count(card => card.Color == CardColor.Black);
        int redCardsCount = deck.cards.Count(card => card.Color == CardColor.Red);

        Assert.That(blackCardsCount, Is.EqualTo(18));
        Assert.That(redCardsCount, Is.EqualTo(18));
        Assert.Pass();
    }
}
