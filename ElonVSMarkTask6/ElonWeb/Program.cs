using System.Reflection;
using Consumers;
using ElonWeb;
using MassTransit;
using Strategy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICardPickStrategy, GameStrategy>();
builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.SetInMemorySagaRepositoryProvider();
    var entryAssembly = Assembly.GetEntryAssembly();
    x.AddConsumers(entryAssembly);
    x.UsingRabbitMq((_, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("Elon_queue", ep =>
        {
            ep.Consumer<DeckConsumer>();
            ep.Consumer<NumberCardConsumer>();
        });
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();