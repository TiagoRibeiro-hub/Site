using Microsoft.Extensions.DependencyInjection;

namespace Games.Core.Services;
public static class ServicesConfig
{
    public static void AddServices(this IServiceCollection services)
    {   
        services.AddScoped<IGameTicTacToeService, GameTicTacToeService>();  
        services.AddScoped<IGameService, GameService>();
    }
}

