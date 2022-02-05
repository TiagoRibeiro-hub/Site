using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TicTacToe.Data;
using TicTacToe.DbActionService;
using TicTacToe.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TicTacToeDbContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("TicTacToeConnection"), config =>
    {
        config.MigrationsAssembly("Data");
    });
});

builder.Services.AddScoped<IDesignTimeDbContextFactory<TicTacToeDbContext>, TicTacToeDbContextFactory>();

builder.Services.AddScoped<IDbActionGameService, DbActionGameService>();
builder.Services.AddScoped<IDbActionHumanService, DbActionHumanService>();

builder.Services.AddScoped<IWinnerService, WinnerService>();
builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IHumanService, HumanService>();
builder.Services.AddScoped<IGameService, GameService>();


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
