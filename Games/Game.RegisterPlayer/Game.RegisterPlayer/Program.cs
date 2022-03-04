using _02.Games.RegisterPlayer.Core.Config;
using Data._DbContext;
using Data.Infrastructure.Config;
using Game.RegisterPlayer.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRegisteredPlayersDbContext();
builder.Services.AddRegisteredPlayersRepositoryServices();
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
app.MapRegisterPlayerEndpoints();

app.Run();
