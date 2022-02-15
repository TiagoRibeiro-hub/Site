using Games.Infrastructure.RepositoryService;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Core.Services;
public static class ServicesConfig
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IReadRepository, GameTicTacToeRepository>();
        services.AddScoped<IRepository, TicTacToeRepository>();
    }
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITotalGamesEasyService, TotalGamesEasyService>();
        services.AddScoped<ITotalGamesHardService, TotalGamesHardService>();
        services.AddScoped<ITotalGamesIntermediateService, TotalGamesIntermediateService>();

        services.AddScoped<ITotalGamesVsComputerService, TotalGamesVsComputerService>();
        services.AddScoped<ITotalGamesVsHumanService, TotalGamesVsHumanService>();

        services.AddScoped<IScoreTableService, ScoreTableService>();
        services.AddScoped<IGameTicTacToeService, GameTicTacToeService>();  

        services.AddScoped<IGameService, GameService>();
    }
}

