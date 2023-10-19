using CardDeck;
using ElonVSmarkTask4;
using Microsoft.Extensions.Hosting;
using Moq;

namespace UnitTests
{
    [TestFixture]
    public class DataBaseTests 
    {
        private IPlayer _elonPlayer;
        private IPlayer _markPlayer;
        private IHostApplicationLifetime _lifetime;

        [SetUp]
        public void SetUp()
        {
            _elonPlayer = new Mock<IPlayer>().Object;
            _markPlayer = new Mock<IPlayer>().Object;
            _lifetime = new Mock<IHostApplicationLifetime>().Object;
        }

        [Test, Order(1)]
        public async Task SaveExperimentConditionsToMemoryAsync()
        {
            using (var context = new ApplicationDbContext(":memory:"))
            {
                var elonPlayer = new Mock<IPlayer>().Object;
                var markPlayer = new Mock<IPlayer>().Object;
                var lifetime = new Mock<IHostApplicationLifetime>().Object;

                var writeWorker = new CollisiumExperimentWorkerDBWrite(context, new ExperimentService(), elonPlayer, markPlayer, lifetime);
                await writeWorker.StartAsync(CancellationToken.None);

                var experimentConditions = context.ExperimentConditions.ToList();

                Assert.That(experimentConditions, Is.Not.Null.And.Not.Empty);
                Assert.That(experimentConditions.Count, Is.EqualTo(100));

                foreach(var condition in experimentConditions)
                {
                    context.ExperimentConditions.Remove(condition);
                }
                await context.SaveChangesAsync();
            }
        }

        [Test, Order(2)]
        public async Task ReadExperimentConditionsFromMemoryAsync()
        {
            using (var context = new ApplicationDbContext(":memory:"))
            {
                var elonPlayer = new Mock<IPlayer>();
                var markPlayer = new Mock<IPlayer>();
                var lifetime = new Mock<IHostApplicationLifetime>();

                var deck = new Deck();

                for (int i = 0; i < 4; i++)
                {
                    var experimentCondition = new ExperimentCondition
                    {
                        Deck = string.Join(",", deck.cards.Select(card => $"{card.Number}:{card.Color}")),
                        Success = true
                    };
                    context.ExperimentConditions.Add(experimentCondition);
                }

                await context.SaveChangesAsync();

                var readWorker = new CollisiumExperimentWorkerDBRead(context, new ExperimentService(), elonPlayer.Object, markPlayer.Object, lifetime.Object);
                await readWorker.StartAsync(CancellationToken.None);

                foreach (var condition in context.ExperimentConditions)
                {
                    Assert.That(condition.Deck, Is.EqualTo(string.Join(",", deck.cards.Select(card => $"{card.Number}:{card.Color}"))));
                    Assert.That(condition.Success, Is.True);
                }
            }
        }
    }
}
