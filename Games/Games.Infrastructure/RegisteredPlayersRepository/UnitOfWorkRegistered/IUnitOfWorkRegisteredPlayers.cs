namespace Games.Infrastructure;

public interface IUnitOfWorkRegisteredPlayers<TEntity> : IDisposable where TEntity : class
{
    IRegisteredPlayersWrite<TEntity> RegisteredPlayersWrite { get; }
    IRegisteredPlayersRead<TEntity> RegisteredPlayersRead { get; }

    Task Complete();
}
