using _00.Data._Entities;

namespace _05.TicTacToe.Core.Repository;

public interface ITicTacToeRepository : IDisposable
{
    ITicTacToeRead<GameEntity> GetTicTacToeGameRead { get; }
    ITicTacToeWrite<GameEntity> GetTicTacToeGameWrite { get; }
    ITicTacToeRead<MovesEntity> GetTicTacToeMovesRead { get; }
    ITicTacToeWrite<MovesEntity> GetTicTacToeMovesWrite { get; }

    Task Complete();
}