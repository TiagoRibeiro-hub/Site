using _02.Play.TicTacToe.Core.Repository.ReadWrite;
using _02.Play.TicTacToe.Core.Repository;
using _02.Play.TicTacToe.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using _02.Play.TicTacToe.Core.WinnerOptions;

namespace _02.Play.TicTacToe.Core.Config;
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
        services.AddScoped<WinnerCheck>();
        services.AddScoped<ITicTacToeService, TicTacToeImplementation>();
        services.AddScoped<IPlayValidationService, PlayValidation>();
        services.AddScoped<IPlayService, PlayImplementation>();
    }

}
