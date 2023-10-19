using CardDeck;
using Strategy;

namespace UnitTests
{
    [TestFixture]
    public class StrategyTests
    {
        [Test]
        public void Win_Strategy()
        {
            ICardStrategy strategy = new GameStrategy();

            Card[] Cards = new Card[]{
                new Card(0, CardColor.Black),
                new Card(1, CardColor.Red),
                new Card(2, CardColor.Red),
                new Card(3, CardColor.Red),
                new Card(4, CardColor.Red),
                new Card(5, CardColor.Red),
                new Card(6, CardColor.Red),
                new Card(7, CardColor.Red),
                new Card(8, CardColor.Red),
                new Card(9, CardColor.Red),
                new Card(10, CardColor.Red),
                new Card(11, CardColor.Red),
                new Card(12, CardColor.Red),
                new Card(13, CardColor.Red),
                new Card(14, CardColor.Red),
                new Card(15, CardColor.Red),
                new Card(16, CardColor.Red),
                new Card(17, CardColor.Black)
            };

            var SelectedCard = strategy.SelectCard(Cards);

            Assert.That(SelectedCard, Is.EqualTo(1));
            Assert.Pass();
        }

        [Test]
        public void Lose_Strategy()
        {
            ICardStrategy strategy = new GameStrategy();

            Card[] Cards = new Card[]{
                new Card(0, CardColor.Black),
                new Card(1, CardColor.Black),
                new Card(2, CardColor.Black),
                new Card(3, CardColor.Black),
                new Card(4, CardColor.Black),
                new Card(5, CardColor.Black),
                new Card(6, CardColor.Black),
                new Card(7, CardColor.Black),
                new Card(8, CardColor.Black),
                new Card(9, CardColor.Black),
                new Card(10, CardColor.Black),
                new Card(11, CardColor.Black),
                new Card(12, CardColor.Black),
                new Card(13, CardColor.Black),
                new Card(14, CardColor.Black),
                new Card(15, CardColor.Black),
                new Card(16, CardColor.Black),
                new Card(17, CardColor.Black)
            };

            var SelectedCard = strategy.SelectCard(Cards);

            Assert.That(SelectedCard, Is.EqualTo(Cards.Length - 1));
            Assert.Pass();
        }
    }
}