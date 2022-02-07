using TicTacToe.Data;

namespace TicTacToe.Services;
public interface IComputerService
{
    Task UpdateTotalGamesVsComputerAsync<TEntity>(TEntity entity) where TEntity : class;

    Task<object> GetTotalGamesScoreTableIdAsync<TEntity>(TEntity entity, int scoreTableId) where TEntity : class;

}

