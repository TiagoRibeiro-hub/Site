using _00.Game.Initialize.Data._DbContext;
using _02.Game.Initialize.Core.Config;
using Data.Infrastructure.Config;
using Game.Initialize.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInitializeGameDbContext();
builder.Services.AddInitializeGameServices();
builder.Services.AddGameOptions();
builder.Services.AddServices();
builder.Services.AddValidationErrorService();

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

app.MapInitializeGameEndpoints();

app.Run();

