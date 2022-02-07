using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public interface IDbActionScoreTableService
{
    Task<bool> IsRegisterByPlayerName(string playerName);
    Task<int> GetScoresTableIdByPlayerNameAsync(string playerName);
    Task<object> GetTotalGamesScoreTableIdAsync<TEntity>(TEntity entity, int scoreTableId) where TEntity : class;
    Task<HashSet<ScoresTableModel>> GetTotalGamesVsHumanAsync(string playerName1, string playerName2);
    Task<ScoresTableModel> GetTotalGamesVsComputerAsync(string playerName1);
}

