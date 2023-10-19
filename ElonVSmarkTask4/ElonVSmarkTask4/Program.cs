using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CardDeck;
using Strategy;
using ElonVSmarkTask4;

class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("[noDB, writeDB, readDB]");
        }
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                switch (args[0])
                {
                    case "writeDB":
                        services.AddHostedService<CollisiumExperimentWorkerDBWrite>();
                        break;
                    case "readDB":
                        services.AddHostedService<CollisiumExperimentWorkerDBRead>();
                        break;
                    case "noDB":
                        services.AddHostedService<CollisiumExperimentWorker>();
                        break;
                }
                services.AddScoped<IExperimentService, ExperimentService>();
                services.AddScoped<IDeckShuffler, DeckShuffler>();
                services.AddScoped<IPlayer, ElonMask>();
                services.AddScoped<IPlayer, MarkZuckerberg>();
                services.AddScoped<ICardStrategy, GameStrategy>();
                services.AddDbContext<ApplicationDbContext>();
            });
    }
}