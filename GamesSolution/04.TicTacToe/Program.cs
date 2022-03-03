using _04.TicTacToe._03.Web.Endpoints.InitializeGame;
using _04.TicTacToe._03.Web.Endpoints.PlayGame;
using _05.TicTacToe.Core;
using _06.TicTacToe.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTicTacToeDbContext();
builder.Services.AddRepository();
builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoints
app.MapInitializeGameEndpoints();
app.MapPlayEndpoints();

app.Run();
