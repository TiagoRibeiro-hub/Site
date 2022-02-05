using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public interface IDbActionGameService
{
    Task<bool> IsRegisterByPlayerName(string playerName);
    Task InsertScoresTableAsync(ScoresTableModel scoreTable);
    Task<int> GetScoresTableIDByPlayerNameAsync(string playerName);  
    Task<ScoresTableModel> GetScoresTableByPlayerNameAsync(string playerName);
    Task RegisterMove(Game game);
}

