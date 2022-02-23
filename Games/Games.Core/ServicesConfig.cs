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


        services.AddScoped<IInitializeService, InitializeService>();
        services.AddScoped<IRegisterPlayerService, RegisterPlayerService>();
        services.AddScoped<IGamePhasesService, GamePhasesService>();
    }
}

