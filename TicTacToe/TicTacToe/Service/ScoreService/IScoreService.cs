using TicTacToe.Data;

namespace TicTacToe.Service
{
    public interface IScoreService
    {
        Task<ScoresTableModel> ScoresTableVsHumanAsync(string email);
    }
}
