namespace TicTacToe.Service;
public interface IWinnerService
{
    Task<Winner> GetWinnerAsync(Game game);
}

