using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonVSmarkTask3
{
    public class CollisiumExperimentWorker : BackgroundService
    {
        private IExperimentService _experimentService;
        private readonly IPlayer _elonPlayer;
        private readonly IPlayer _markPlayer;

        public CollisiumExperimentWorker(IExperimentService experimentService, IPlayer elonPlayer, IPlayer markPlayer)
        {
            _experimentService = experimentService;
            _elonPlayer = elonPlayer;
            _markPlayer = markPlayer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var deck = new CardDeck.Deck();
            const int totalExperiments = 1_000_000;
            int totalSuccesses = 0;

            for (int i = 0; i < totalExperiments; i++)
            {
                int successes = _experimentService.RunExperiment(new DeckShuffler(), deck, _elonPlayer, _markPlayer).Result;
                totalSuccesses += successes;
            }

            double successRate = ((double)totalSuccesses / totalExperiments) * 100;
            Console.Write("Процент успешных боёв: " + successRate + "%");

            return Task.CompletedTask;
        }
    }
}
