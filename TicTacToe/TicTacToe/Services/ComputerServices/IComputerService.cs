using TicTacToe.Data;

namespace TicTacToe.Services;
public interface IComputerService
{
    Task<TotalGamesEasyModel> GetTotalGamesEasyByScoreTableIdAsync(int scoreTableId);
    Task<TotalGamesIntermediateModel> GetTotalGamesIntermediateByScoreTableIdAsync(int scoreTableId);
    Task<TotalGamesHardModel> GetTotalGamesHardByScoreTableIdAsync(int scoreTableId);

    Task UpdateTotalGamesVsComputerAsync<TEntity>(TEntity entity) where TEntity : class;

}

