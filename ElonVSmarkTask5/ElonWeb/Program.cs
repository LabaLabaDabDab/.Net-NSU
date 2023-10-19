using Strategy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICardStrategy, GameStrategy>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
