using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;
using TicTacToeClass;

namespace TicTacToe.DbActionService;
public class HumanService : IHumanService
{
    private readonly IDbActionService _dbActionService;
    private readonly IDbActionGameService _dbActionGameService;

    public HumanService(
        TicTacToeDbContext db, IDbActionService dbActionService, 
        IDbActionGameService dbActionGameService)
    {
        _dbActionService = dbActionService;
        _dbActionGameService = dbActionGameService;
    }
    public async Task<TotalGamesVsHumanModel> GetTotalGamesVsHumanByScoreTableIdAsync(int scoreTableId)
    {
        try
        {
            TotalGamesVsHumanModel totalGamesVsHuman = new();
            totalGamesVsHuman = (TotalGamesVsHumanModel)await _dbActionService.GetTotalGamesScoreTableIdAsync(totalGamesVsHuman, scoreTableId);
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
            var players = await _dbActionGameService.GetTotalGameVsHumanTable(winner);
            TotalGamesVsHumanModel player1 = new();
            TotalGamesVsHumanModel player2 = new();
            int count = 0;
            foreach (var item in players)
            {
                if(count == 0)
                {
                    count += 1;
                    player1 = await GetTotalGamesVsHumanByScoreTableIdAsync(item.ScoreTableId);
                    player1.Victories = item.Victories;
                    player1.Losses = item.Losses;
                    player1.Ties = item.Ties;
                }
                else
                {
                    count += 1;
                    player2 = await GetTotalGamesVsHumanByScoreTableIdAsync(item.ScoreTableId);
                    player2.Victories = item.Victories;
                    player2.Losses = item.Losses;
                    player2.Ties = item.Ties;
                }
            }
            if(count == 1)
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

