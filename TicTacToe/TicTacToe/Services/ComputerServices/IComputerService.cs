using TicTacToe.Data;

namespace TicTacToe.Services;
public interface IComputerService
{
    Task<int> GetEasyPlayedMoveAsync(List<int> possibleMoves);
    Task<int> GetIntermediatePlayedMoveAsync(Game game);
    Task<int> GetHardPlayedMoveAsync(Game game);

}

