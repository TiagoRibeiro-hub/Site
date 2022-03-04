using Data.Infrastructure.Data._Entities;

namespace _02.Games.RegisterPlayer.Core.Repoitory;

public interface IRegisteredPlayersRepository : IDisposable
{
    IRegisteredPlayersWrite<RegisteredPlayersEntity> RegisteredPlayersWrite { get; }
    IRegisteredPlayersRead<RegisteredPlayersEntity> RegisteredPlayersRead { get; }

    Task Complete();
}