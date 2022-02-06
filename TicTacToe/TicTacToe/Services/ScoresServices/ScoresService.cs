using TicTacToe.Data;
using TicTacToe.DbActionService;

namespace TicTacToe.Services;
public class ScoresService : IScoresService
{
    private readonly IHumanService _humanService;
    private readonly IDbActionGameService _dbActionGameService;
    private readonly IComputerService _computerService;
    public ScoresService(IHumanService humanService, IDbActionGameService dbActionGameService, IComputerService computerService)
    {
        _humanService = humanService;
        _dbActionGameService = dbActionGameService;
        _computerService = computerService;
    }

    public async Task TableScoreInitialize(Game game)
    {
        try
        {
            bool isReg = await _dbActionGameService.IsRegisterByPlayerName(game.Player.Name);
            if (!isReg)
            {
                await SetScoresTableAsync(game);
            }
            else
            {
                await UpdateScoreTableAsync(game);
            }
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    private async Task SetScoresTableAsync(Game game)
    {
        try
        {
            ScoresTableModel scoreTable = new()
            {
                PlayerName = game.Player.Name,
                Email = game.Player.Email,
            };

            if (game.IsComputer)
            {
                if (game.Easy)
                {
                    _ = game.Player.StartFirst == true ? scoreTable.TotalGamesVsComputer.TotalGamesEasy.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesEasy.StartSecond += 1;
                    scoreTable.TotalGamesVsComputer.TotalGamesEasy.TotalGames += 1;

                }
                if (game.Intermediate)
                {
                    _ = game.Player.StartFirst == true ? scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.StartSecond += 1;
                    scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.TotalGames += 1;
                }
                if (game.Hard)
                {
                    _ = game.Player.StartFirst == true ? scoreTable.TotalGamesVsComputer.TotalGamesHard.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesHard.StartSecond += 1;
                    scoreTable.TotalGamesVsComputer.TotalGamesHard.TotalGames += 1;
                }
            }
            else
            {
                _ = game.Player.StartFirst == true ? scoreTable.TotalGamesVsHuman.StartFirst += 1 : scoreTable.TotalGamesVsHuman.StartSecond += 1;
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
    private async Task UpdateScoreTableAsync(Game game)
    {
        try
        {
            int scoreTableId = await _dbActionGameService.GetScoresTableIdByPlayerNameAsync(game.Player.Name);
            if (game.IsComputer)
            {
                if (game.Easy)
                {
                    TotalGamesEasyModel vsComputerEasy = await _computerService.GetTotalGamesEasyByScoreTableIdAsync(scoreTableId);
                    _ = game.Player.StartFirst == true ? vsComputerEasy.StartFirst += 1 : vsComputerEasy.StartSecond += 1;
                    vsComputerEasy.TotalGames += 1;
                    await _computerService.UpdateTotalGamesVsComputerAsync(vsComputerEasy);
                }
                if (game.Intermediate)
                {
                    TotalGamesIntermediateModel vsComputerIntermediate = await _computerService.GetTotalGamesIntermediateByScoreTableIdAsync(scoreTableId);
                    _ = game.Player.StartFirst == true ? vsComputerIntermediate.StartFirst += 1 : vsComputerIntermediate.StartSecond += 1;
                    vsComputerIntermediate.TotalGames += 1;
                    await _computerService.UpdateTotalGamesVsComputerAsync(vsComputerIntermediate);
                }
                if (game.Hard)
                {
                    TotalGamesHardModel vsComputerHard = await _computerService.GetTotalGamesHardByScoreTableIdAsync(scoreTableId);
                    _ = game.Player.StartFirst == true ? vsComputerHard.StartFirst += 1 : vsComputerHard.StartSecond += 1;
                    vsComputerHard.TotalGames += 1;
                    await _computerService.UpdateTotalGamesVsComputerAsync(vsComputerHard);
                }
            }
            else
            {
                TotalGamesVsHumanModel vsHumanModel = await _humanService.GetTotalGamesVsHumanByScoreTableIdAsync(scoreTableId);
                _ = game.Player.StartFirst == true ? vsHumanModel.StartFirst += 1 : vsHumanModel.StartSecond += 1;
                await _humanService.UpdateTotalGamesVsHumanAsync(vsHumanModel);
            }
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }

    }

}

