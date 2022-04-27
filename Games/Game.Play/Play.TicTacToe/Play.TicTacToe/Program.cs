using _00.Play.TicTacToe.Data._DbContext;
using _02.Play.TicTacToe.Core.Config;
using _02.Play.TicTacToe.Core.Events;
using Data.Infrastructure.Config;
using Play.TicTacToe.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTicTacToeDbContext();
builder.Services.AddRepository();
builder.Services.AddServices();
builder.Services.AddValidationErrorService();

//MassTransit
builder.Services.AddMassTransitService();


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
app.MapPlayEndpoints();
app.Run();

