using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;
using TicTacToe.Services;
using TicTacToeClass;

namespace TicTacToe.DbActionService;
public class HumanService : IHumanService
{
    private readonly IDbActionScoreTableService _dbActionScoreTableService;
    public readonly IDbActionService _dbActionService;

    public HumanService(IDbActionScoreTableService dbActionScoreTableService, IDbActionService dbActionService)
    {
        _dbActionScoreTableService = dbActionScoreTableService;
        _dbActionService = dbActionService;
    }
    public async Task<TotalGamesVsHumanModel> GetTotalGamesVsHumanByScoreTableIdAsync(int scoreTableId)
    {
        try
        {
            TotalGamesVsHumanModel totalGamesVsHuman = new();
            totalGamesVsHuman = (TotalGamesVsHumanModel)await _dbActionScoreTableService.GetTotalGamesScoreTableIdAsync(totalGamesVsHuman, scoreTableId);
            if (totalGamesVsHuman is null)
            {
                throw new Exception();
            }
            return totalGamesVsHuman;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task SetScoresTableFinishedGame(Winner winner)
    {
        try
        {
            var players = await _dbActionScoreTableService.GetTotalGamesVsHumanAsync(winner.PlayerName1, winner.PlayerName2);
            TotalGamesVsHumanModel player1 = new();
            TotalGamesVsHumanModel player2 = new();
            int count = 0;
            foreach (var item in players)
            {
                if (count == 0)
                {
                    count += 1;
                    HumanServiceFuncs.SetTotalGamesVsHuman(winner, player1, item);
                }
                else
                {
                    count += 1;
                    HumanServiceFuncs.SetTotalGamesVsHuman(winner, player2, item);
                }
            }
            if (count == 1)
            {
                await _dbActionService.UpdateAsync(player1);
            }
            else
            {
                await _dbActionService.UpdateRangeAsync(player1, player2);
            }
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task UpdateTotalGamesVsHumanAsync(TotalGamesVsHumanModel totalGamesVsHumanModel)
    {
        try
        {
            await _dbActionService.UpdateAsync(totalGamesVsHumanModel);
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

}
