using _02.Game.Initialize.Core.GameOptions;
using _02.Game.Initialize.Core.Repository;
using _02.Game.Initialize.Core.Repository.ReadWrite;
using _02.Game.Initialize.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace _02.Game.Initialize.Core.Config;
public static class ServiceConfig
{
    public static void AddInitializeGameServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IInitializeGameRead<>), typeof(InitializeGameRead<>));
        services.AddScoped(typeof(IInitializeGameWrite<>), typeof(InitializeGameWrite<>));
        // 
        services.AddScoped<IInitializeGameRepository, InitializeGameRepository>();
    }

    public static void AddGameOptions(this IServiceCollection services)
    {
        services.AddScoped<SetInitialPossibleMoves>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IInitializeGameOptionsService, InitializeGameOptions>();
        services.AddScoped<IInitializeGameValidationService, InitializeGameValidation>();
        services.AddScoped<IInitializeGameService, InitializeGameImplementation>();
    }
}
