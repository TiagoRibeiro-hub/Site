using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Data;
using TicTacToe.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TicTacToeDbContext>(config =>
{
    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
    if (baseDir.Contains("bin"))
    {
        int index = baseDir.IndexOf("bin");
        baseDir = baseDir.Substring(0, index);
    }
    config.UseSqlite($"Data Source={baseDir}Data\\Database\\tictactoe.db");
});

builder.Services.AddScoped<IDesignTimeDbContextFactory<TicTacToeDbContext>, TicTacToeDbContextFactory>();

builder.Services.AddScoped<IScoreService, ScoreService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(config =>
{
    config.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
