using TicTacToe.Data;

namespace TicTacToe.Services;
public interface IComputerService
{
    Task<int> GetEasyPlayedMoveAsync(Game game);
    Task<int> GetIntermediatePlayedMoveAsync(Game game);
    Task<int> GetHardPlayedMoveAsync(Game game);

}

