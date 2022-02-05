using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public interface IDbActionHumanService
{
    Task<TotalGamesVsHumanModel> GetScoresVsHumanByScoreTableIdAsync(int scoreTableId);
    Task UpdateScoresTableTotalGamesVsHumanAsync(TotalGamesVsHumanModel totalGamesVsHumanModel);
}

