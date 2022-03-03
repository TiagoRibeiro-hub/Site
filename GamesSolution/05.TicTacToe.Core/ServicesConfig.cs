using _05.TicTacToe.Core.InitializeGameService;
using _05.TicTacToe.Core.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace _05.TicTacToe.Core;
public static class ServicesConfig
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(ITicTacToeRead<>), typeof(TicTacToeRead<>));
        services.AddScoped(typeof(ITicTacToeWrite<>), typeof(TicTacToeWrite<>));
        services.AddScoped<ITicTacToeRepository, TicTacToeRepository>();
    }
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IInitializeGameService, InitializeGame>();
    }
}

