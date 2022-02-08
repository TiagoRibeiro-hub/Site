using TicTacToe.Data;

namespace TicTacToe.Services;
public interface IComputerService
{
    Task<int> GetEasyPlayedMoveAsync(List<int> possibleMoves);
    Task<int> GetIntermediatePlayedMoveAsync(List<int> possibleMoves);
    Task<int> GetHardPlayedMoveAsync(List<int> possibleMoves);

}

