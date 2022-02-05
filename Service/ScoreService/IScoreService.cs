using TicTacToe.Data;

namespace TicTacToe.Service
{
    public interface IScoreService
    {
        Task SetScoresTableHumanAsync(Human player);
        Task ScoresTableVsHumanAsync(string email, bool startFirst);
        Task ScoresTableVsComputerAsync(string email, bool startFirst, string difficulty);

    }
}
