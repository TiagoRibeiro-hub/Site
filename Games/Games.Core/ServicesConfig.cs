using Microsoft.Extensions.DependencyInjection;

namespace Games.Core;
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

        
        services.AddScoped<ScoreTableFuncs>();
        services.AddScoped<IScoreTableService, ScoreTableService>();

        services.AddScoped<WinnerFuncs>();
        services.AddScoped<GameFuncs>();
        services.AddScoped<IGameTicTacToeService, GameTicTacToeService>();  

        services.AddScoped<IGameService, GameService>();
    }
}

