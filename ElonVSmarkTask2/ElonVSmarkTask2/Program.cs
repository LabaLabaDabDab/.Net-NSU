using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CardDeck;
using Strategy;
using ElonVSmarkTask2;
using Microsoft.Extensions.Configuration;

class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<CollisiumExperimentWorker>();
                services.AddScoped<IExperimentService, ExperimentService>();
                services.AddScoped<IDeckShuffler, DeckShuffler>();                
                services.AddScoped<ICardStrategy, GameStrategy>();                         
            });
    }
}