using Games.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Games.Core;
public static class ServicesConfig
{
    public static void AddRepositorys(this IServiceCollection services)
    {
        services.AddScoped<IRegisteredPlayersRepository, RegisteredPlayersRepository>();
        services.AddScoped<IRegisteredPlayersWrite, RegisteredPlayersWrite>();
        services.AddScoped<IRegisteredPlayersRead, RegisteredPlayersRead>();

        services.AddScoped<ITicTacToeRepository, TicTacToeRepository>();
        services.AddScoped<ITicTacToeWrite, TicTacToeWrite>();
        services.AddScoped<ITicTacToeRead, TicTacToeRead>();

        services.AddRepositoryService();
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

        services.AddScoped<ITicTacToeService, TicTacToeService>();
        services.AddScoped<IGameService, GameService>();
    }
}

