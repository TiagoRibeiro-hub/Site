using TicTacToe.Data;

namespace TicTacToe.Service;
public interface IGameDbService
{
    Task<int> InsertInitializeGame(GameModel game);
    Task RegisterMove(Game game);
}

