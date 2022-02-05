using TicTacToe.Data;
using TicTacToe.DbActionService;

namespace TicTacToe.Services;
public class HumanService : IHumanService
{
    private readonly IDbActionHumanService _dbActionHumanService;
    private readonly IDbActionGameService _dbActionGameService;
    public HumanService(IDbActionHumanService dbActionHumanService, IDbActionGameService dbActionGameService)
    {
        _dbActionHumanService = dbActionHumanService;
        _dbActionGameService = dbActionGameService;
    }

    public async Task TableScoreInitialize(Human player)
    {
        try
        {
            bool isReg = await _dbActionGameService.IsRegisterByPlayerName(player.Name);
            if (!isReg)
            {
                await SetScoresTableInitializeAsync(player);
            }
            else
            {
                await UpdateScoreTableInitializeAsync(player);
            }
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    private async Task SetScoresTableInitializeAsync(Human player)
    {
        try
        {
            ScoresTableModel scoreTable = new()
            {
                PlayerName = player.Name,
                Email = player.Email,
            };

            if (player.IsComputer)
            {
                if (player.Difficulty == Difficulty.Easy.ToString().ToUpper())
                {
                    _ = player.StartFirst == true ? scoreTable.TotalGamesVsComputer.TotalGamesEasy.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesEasy.StartSecond += 1;
                    scoreTable.TotalGamesVsComputer.TotalGamesEasy.TotalGames += 1;

                }
                if (player.Difficulty == Difficulty.Intermediate.ToString().ToUpper())
                {
                    _ = player.StartFirst == true ? scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.StartSecond += 1;
                    scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.TotalGames += 1;
                }
                if (player.Difficulty == Difficulty.Hard.ToString().ToUpper())
                {
                    _ = player.StartFirst == true ? scoreTable.TotalGamesVsComputer.TotalGamesHard.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesHard.StartSecond += 1;
                    scoreTable.TotalGamesVsComputer.TotalGamesHard.TotalGames += 1;
                }
            }
            else
            {
                _ = player.StartFirst == true ? scoreTable.TotalGamesVsHuman.StartFirst += 1 : scoreTable.TotalGamesVsHuman.StartSecond += 1;
                scoreTable.TotalGamesVsHuman.TotalGames += 1;
            }
            await _dbActionGameService.InsertScoresTableAsync(scoreTable);
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    private async Task UpdateScoreTableInitializeAsync(Human player)
    {
        try
        {
            int scoreTableId = await _dbActionGameService.GetScoresTableIDByPlayerNameAsync(player.Name);
            TotalGamesVsHumanModel vsHumanModel = await _dbActionHumanService.GetScoresVsHumanByScoreTableIdAsync(scoreTableId);
            _ = player.StartFirst == true ? vsHumanModel.StartFirst += 1 : vsHumanModel.StartSecond += 1;
            await _dbActionHumanService.UpdateScoresTableTotalGamesVsHumanAsync(vsHumanModel);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }

    }

}

