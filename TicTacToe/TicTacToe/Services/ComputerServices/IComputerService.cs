using TicTacToe.Data;

namespace TicTacToe.Services;
public interface IComputerService
{
    Task<string> GetEasyPlayedMoveAsync(Game game);
    Task<string> GetIntermediatePlayedMoveAsync(Game game);
    Task<string> GetHardPlayedMoveAsync(Game game);

}

