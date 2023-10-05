using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonVSmarkTask2
{
    public class CollisiumExperimentWorker : BackgroundService
    {
        private IExperimentService _experimentService;
        
        public CollisiumExperimentWorker(IExperimentService experimentService)
        {
            _experimentService = experimentService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var deck = new CardDeck.Deck();
            const int totalExperiments = 1_000_000;
            int totalSuccesses = 0;
            
            for (int i = 0; i < totalExperiments; i++)
            {
                int successes = _experimentService.RunExperiment(new DeckShuffler(), deck).Result;
                totalSuccesses += successes;
            }

            double successRate = ((double)totalSuccesses / totalExperiments) * 100;
            Console.Write("Процент успешных боёв: " + successRate + "%");

            return Task.CompletedTask;
        }
    }
}
