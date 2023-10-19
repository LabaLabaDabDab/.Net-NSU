using Microsoft.Extensions.Hosting;

namespace ElonVSmarkTask4
{
    public class CollisiumExperimentWorker : BackgroundService
    {
        private IExperimentService _experimentService;
        private readonly IPlayer _elonPlayer;
        private readonly IPlayer _markPlayer;
        private readonly IHostApplicationLifetime _lifeTime;

        public CollisiumExperimentWorker(IExperimentService experimentService, IPlayer elonPlayer, IPlayer markPlayer, IHostApplicationLifetime lifeTime)
        {
            _experimentService = experimentService;
            _elonPlayer = elonPlayer;
            _markPlayer = markPlayer;
            _lifeTime = lifeTime;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var deck = new CardDeck.Deck();
            const int totalExperiments = 1_000_000;
            int totalSuccesses = 0;

            for (int i = 0; i < totalExperiments && !stoppingToken.IsCancellationRequested; i++)
            {
                int successes = _experimentService.RunExperiment(new DeckShuffler(), deck, _elonPlayer, _markPlayer).Result;
                totalSuccesses += successes;
            }

            double successRate = ((double)totalSuccesses / totalExperiments) * 100;
            Console.Write("Процент успешных боёв: " + successRate + "%");

            _lifeTime.StopApplication();

            return Task.CompletedTask;
        }
    }
}
