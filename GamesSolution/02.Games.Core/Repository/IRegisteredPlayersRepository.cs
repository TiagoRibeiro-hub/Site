using _01.Games.Data._DbContext;

namespace _02.Games.Core.Repository;

public interface IRegisteredPlayersRepository : IDisposable
{
    IRegisteredPlayersWrite<RegisteredPlayersEntity> RegisteredPlayersWrite { get; }
    IRegisteredPlayersRead<RegisteredPlayersEntity> RegisteredPlayersRead { get; }

    Task Complete();
}
