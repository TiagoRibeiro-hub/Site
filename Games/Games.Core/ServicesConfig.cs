using Games.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Games.Core;
public static class ServicesConfig
{
    public static void AddRepositorys(this IServiceCollection services)
    {
        services.AddTicTacToeRepositorys();
        services.AddRegisteredPlayersRepositorys();
        services.AddRepositoryService();
    }
    public static void AddServices(this IServiceCollection services)
    {

        services.AddScoped<ITicTacToeService, TicTacToeService>();
        services.AddScoped<IGameTicTacToeService, GameTicTacToeService>();

        services.AddScoped<IInitializePhaseService, InitializePhaseService>();
        services.AddScoped<IRegisterPlayerPhaseService, RegisterPlayerPhaseService>();
        services.AddScoped<IGamePhasesService, GamePhasesService>();
    }
}

