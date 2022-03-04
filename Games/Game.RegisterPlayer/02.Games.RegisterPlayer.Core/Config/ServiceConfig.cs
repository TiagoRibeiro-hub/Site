using _02.Games.RegisterPlayer.Core.Repoitory;
using _02.Games.RegisterPlayer.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace _02.Games.RegisterPlayer.Core.Config;
public static class ServiceConfig
{
    public static void AddRegisteredPlayersRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRegisteredPlayersRead<>), typeof(RegisteredPlayersRead<>));
        services.AddScoped(typeof(IRegisteredPlayersWrite<>), typeof(RegisteredPlayersWrite<>));
        // 
        services.AddScoped<IRegisteredPlayersRepository, RegisteredPlayersRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterPlayerValidationService, RegisterPlayerValidation>();
        services.AddScoped<IRegisterPlayerService, RegisterPlayerImplementation>();
    }
}
