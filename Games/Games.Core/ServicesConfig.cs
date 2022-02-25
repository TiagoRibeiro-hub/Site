using Games.Core.Validatons;
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
        // TicTacToe
        services.AddScoped<ITicTacToeService, TicTacToeImplementation>();
        services.AddScoped<IGameTicTacToeService, GameTicTacToeService>();
        // Games
        services.AddScoped<IPlayPhaseService, PlayPhaseService>();
        services.AddScoped<IInitializePhaseService, InitializePhaseService>();
        services.AddScoped<IRegisterPlayerPhaseService, RegisterPlayerPhaseService>();
        services.AddScoped<IGamePhasesService, GamePhasesService>();
        // Validation
        services.AddScoped<IValidationService, ValidationService>();
    }
}

