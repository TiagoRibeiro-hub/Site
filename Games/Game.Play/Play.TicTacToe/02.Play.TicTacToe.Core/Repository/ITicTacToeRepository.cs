using _02.Play.TicTacToe.Core.Repository.ReadWrite;
using Data.Infrastructure.Data._Entities;

namespace _02.Play.TicTacToe.Core.Repository;

public interface ITicTacToeRepository : IDisposable
{
    ITicTacToeRead<GameEntity> GetTicTacToeGameRead { get; }
    ITicTacToeWrite<GameEntity> GetTicTacToeGameWrite { get; }
    ITicTacToeRead<MovesEntity> GetTicTacToeMovesRead { get; }
    ITicTacToeWrite<MovesEntity> GetTicTacToeMovesWrite { get; }

    Task Complete();
}

