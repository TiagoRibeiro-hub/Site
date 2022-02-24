using Microsoft.Extensions.DependencyInjection;

namespace Games.Infrastructure;
public static class RepositoryConfig
{
    public static void AddRegisteredPlayersRepositorys(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWorkRegisteredPlayers<>), typeof(UnitOfWorkRegisteredPlayers<>));
        services.AddScoped(typeof(IRegisteredPlayersWrite<>), typeof(RegisteredPlayersWrite<>));
        services.AddScoped(typeof(IRegisteredPlayersRead<>), typeof(RegisteredPlayersRead<>));
        services.AddScoped<IRegisteredPlayersRepository, RegisteredPlayersRepository>();
    }

    public static void AddTicTacToeRepositorys(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWorkTicTacToe<>), typeof(UnitOfWorkTicTacToe<>));
        services.AddScoped(typeof(ITicTacToeWrite<>), typeof(TicTacToeWrite<>));
        services.AddScoped(typeof(ITicTacToeRead<>), typeof(TicTacToeRead<>));
        services.AddScoped<ITicTacToeReadRepository, TicTacToeReadRepository>();
        services.AddScoped<ITicTacToeWriteRepository, TicTacToeWriteRepository>();
    }
}

