using CardDeck;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ElonVSmarkTask4
{
    public class CollisiumExperimentWorkerDBRead : IHostedService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IExperimentService _experimentService;
        private readonly IPlayer _elonPlayer;
        private readonly IPlayer _markPlayer;
        private readonly IHostApplicationLifetime _lifeTime;

        public CollisiumExperimentWorkerDBRead(ApplicationDbContext dbContext, IExperimentService experimentService, IPlayer elonPlayer, IPlayer markPlayer, IHostApplicationLifetime lifeTime)
        {
            _dbContext = dbContext;
            _experimentService = experimentService;
            _elonPlayer = elonPlayer;
            _markPlayer = markPlayer;
            _lifeTime = lifeTime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            int totalSuccesses = 0;
            var experiments = await _dbContext.ExperimentConditions.ToListAsync();
            int totalExperiments = 0;

            foreach (var experimentCondition in experiments)
            {
                var deck = new Deck();
                deck.Clear();
                var deckInfo = experimentCondition.Deck.Split(',');

                foreach (var cardInfo in deckInfo)
                {
                    var parts = cardInfo.Split(':');
                    if (int.TryParse(parts[0], out int number) && Enum.TryParse(parts[1], out CardColor color))
                    {
                        deck.cards.Add(new Card(number, color));
                    }

                }
                int successes = _experimentService.RunExperiment(null, deck, _elonPlayer, _markPlayer).Result;
                totalExperiments++;
                totalSuccesses += successes;
            }
            double successRate = ((double)totalSuccesses / totalExperiments) * 100;
            Console.WriteLine("Процент успешных боёв: " + successRate + "%");

            _lifeTime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
