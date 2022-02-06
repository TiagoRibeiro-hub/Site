using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public interface IHumanService
{
    Task<TotalGamesVsHumanModel> GetTotalGamesVsHumanByScoreTableIdAsync(int scoreTableId);
    Task SetScoresTableFinishedGame(Winner winner);
    Task UpdateTotalGamesVsHumanAsync(TotalGamesVsHumanModel totalGamesVsHumanModel);
}

