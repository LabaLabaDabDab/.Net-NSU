using CardDeck;
using Microsoft.Extensions.Hosting;

namespace ElonVSmarkTask4
{
    public class CollisiumExperimentWorkerDBWrite : IHostedService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IExperimentService _experimentService;
        private readonly IPlayer _elonPlayer;
        private readonly IPlayer _markPlayer;
        private readonly IHostApplicationLifetime _lifeTime;

        public CollisiumExperimentWorkerDBWrite(ApplicationDbContext dbContext, IExperimentService experimentService, IPlayer elonPlayer, IPlayer markPlayer, IHostApplicationLifetime lifeTime)
        {
            _dbContext = dbContext;
            _experimentService = experimentService;
            _elonPlayer = elonPlayer;
            _markPlayer = markPlayer;
            _lifeTime = lifeTime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            const int totalExperiments = 100;
            int totalSuccesses = 0;

            for (int i = 0; i < totalExperiments && !cancellationToken.IsCancellationRequested; i++)
            {
                var deck = new Deck();

                int successes = await _experimentService.RunExperiment(new DeckShuffler(), deck, _elonPlayer, _markPlayer);

                var experimentCondition = new ExperimentCondition
                {
                    Deck = string.Join(",", deck.cards.Select(card => $"{card.Number}:{card.Color}")),
                    Success = successes > 0
                };

                totalSuccesses += successes;

                _dbContext.ExperimentConditions.Add(experimentCondition);
                await _dbContext.SaveChangesAsync(cancellationToken);
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
