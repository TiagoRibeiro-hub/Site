using Games.Core.Services;
using Games.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTicTacToeDbContext();
builder.Services.AddChessDbContext();

builder.Services.AddServices();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
