using TicTacToe.Data;

namespace TicTacToe.Service
{
    public interface IScoreService
    {
        Task ScoresTableVsHumanAsync(string email);
        Task ScoresTableVsComputerAsync(string email, string difficulty);

        ScoresTableModel GetScoreTableByEmail(string email);
        bool IsRegisterByEmail(string email);
        int GetScoreTableIdByEmail(string email);
    }
}
