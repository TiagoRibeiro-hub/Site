using _00.Infrastructure.Repository;
using _02.Games.Core.Repository;
using _02.Games.Core.Services._03_InitializePhase;
using _02.Games.Core.Services._04.HttpClientTicTacToe;
using _02.Games.Core.Services.GamePhases;
using _02.Games.Core.Services.RegisterPlayerPhase;
using _02.Games.Core.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace _02.Games.Core.ServicesConfig;
public static class ServicesConfig
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddRepositoryService();
        services.AddRegisteredPlayersRepositoryServices();      
    }
    public static void AddServices(this IServiceCollection services)
    {
        // HttpClients
        services.AddScoped<HttpTicTacToe>();
        // Games Phases
        services.AddScoped<IInitializePhaseService, InitializePhase>();
        services.AddScoped<IRegisterPlayerPhaseService, RegisterPlayerPhase>();
        // Game
        services.AddScoped<IGamePhasesService, GamePhases>();
        // Validation
        services.AddScoped<IValidationService, ValidationService>();
    }

    public static void AddHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<HttpTicTacToe>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7154");
        });
    }
}
