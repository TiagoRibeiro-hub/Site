using TicTacToe.Data;

namespace TicTacToe.Service
{
    public interface IScoreService
    {
        Task SetScoresTableAsync(Human player);
        Task ScoresTableVsHumanAsync(string email);
        Task ScoresTableVsComputerAsync(string email, string difficulty);

    }
}
