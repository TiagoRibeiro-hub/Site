using TicTacToe.Data;

namespace TicTacToe.Service;
public interface IScoreDbService
{
    ScoresTableModel GetScoreTableByEmail(string email);
    bool IsRegisterByEmail(string email);
    int GetScoreTableIdByEmail(string email);
    Task InsertScoresTableAsync(ScoresTableModel model);
    Task UpdateScoreTableAsync(string email, bool isComputer = false, string difficulty = "");
}

