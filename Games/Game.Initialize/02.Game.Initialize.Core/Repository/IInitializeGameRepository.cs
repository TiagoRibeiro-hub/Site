using _02.Game.Initialize.Core.Repository.ReadWrite;
using Data.Infrastructure.Data._Entities;

namespace _02.Game.Initialize.Core.Repository;

public interface IInitializeGameRepository : IDisposable
{
    IInitializeGameWrite<GameEntity> InitializeGameWrite { get; }
    IInitializeGameRead<GameEntity> InitializeGameRead { get; }

    Task Complete();
}

