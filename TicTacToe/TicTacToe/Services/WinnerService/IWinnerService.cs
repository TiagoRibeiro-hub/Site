namespace TicTacToe.Services;
public interface IWinnerService
{
    Task<HashSet<int>> GetListMovesAsync(Game game);
    Task<Winner> GetWinnerAsync(Game game);
}

