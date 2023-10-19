using CardDeck;
using ElonVSmarkTask4;
using Moq;
using Strategy;

namespace UnitTests
{
    public class ExperimentServiceTests
    {
        [Test]
        public void RunExperiment_Should_Shuffle_Deck_Once()
        {
            var deck = new Deck();
            var mockDeckShuffler = new Mock<IDeckShuffler>();
            var experimentService = new ExperimentService();

            mockDeckShuffler.Setup(shuffler => shuffler.ShuffleDeck(It.IsAny<List<Card>>()))
                        .Returns((List<Card> inputDeck) => inputDeck);

            experimentService.RunExperiment(mockDeckShuffler.Object, deck, new ElonMask(new GameStrategy()), new MarkZuckerberg(new GameStrategy())).Wait();

            mockDeckShuffler.Verify(shuffler => shuffler.ShuffleDeck(It.IsAny<List<Card>>()), Times.Once);
            Assert.Pass();
        }

        [Test]
        public void Experiment_Result_With_Known_Shuffled_Deck()
        {
            var deck = new Deck();
            List<Card> preShuffledDeck = new List<Card>{
                new Card(0, CardColor.Red),
                new Card(1, CardColor.Black),
                new Card(2, CardColor.Black),
                new Card(3, CardColor.Black),
                new Card(4, CardColor.Red),
                new Card(5, CardColor.Red),
                new Card(6, CardColor.Black),
                new Card(7, CardColor.Black),
                new Card(8, CardColor.Red),
                new Card(9, CardColor.Red),
                new Card(10, CardColor.Black),
                new Card(11, CardColor.Black),
                new Card(12, CardColor.Red),
                new Card(13, CardColor.Red),
                new Card(14, CardColor.Black),
                new Card(15, CardColor.Black),
                new Card(16, CardColor.Red),
                new Card(17, CardColor.Red),
                new Card(18, CardColor.Red),
                new Card(19, CardColor.Black),
                new Card(20, CardColor.Red),
                new Card(21, CardColor.Red),
                new Card(22, CardColor.Black),
                new Card(23, CardColor.Black),
                new Card(24, CardColor.Red),
                new Card(25, CardColor.Red),
                new Card(26, CardColor.Black),
                new Card(27, CardColor.Black),
                new Card(28, CardColor.Red),
                new Card(29, CardColor.Red),
                new Card(30, CardColor.Black),
                new Card(31, CardColor.Black),
                new Card(32, CardColor.Red),
                new Card(33, CardColor.Red),
                new Card(34, CardColor.Black),
                new Card(35, CardColor.Black)
            };

            var mockDeckShuffler = new Mock<IDeckShuffler>();
            mockDeckShuffler.Setup(shuffler => shuffler.ShuffleDeck(It.IsAny<List<Card>>()))
                            .Returns((List<Card> inputDeck) => preShuffledDeck);

            var elonPlayer = new ElonMask(new Mock<ICardStrategy>().Object);
            var markPlayer = new MarkZuckerberg(new Mock<ICardStrategy>().Object);

            var experimentService = new ExperimentService();
            var result = experimentService.RunExperiment(mockDeckShuffler.Object, deck, elonPlayer, markPlayer).Result;

            Assert.That(result, Is.EqualTo(1));
            Assert.Pass();
        }
    }
}