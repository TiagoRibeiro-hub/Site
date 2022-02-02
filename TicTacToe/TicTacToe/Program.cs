using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TicTacToe.Data;
using TicTacToe.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TicTacToeDbContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("TicTacToeConnection"), config =>
    {
        config.MigrationsAssembly("Data");
    });
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
