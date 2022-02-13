using TicTacToe.Data;
using TicTacToe.DbActionService;

namespace TicTacToe.Services;
public class ScoresService : IScoresService
{
    private readonly IHumanService _humanService;
    private readonly IDbActionService _dbActionService;
    private readonly IDbActionScoreTableService _dbActionScoreTableService;
    private readonly IDbActionGameService _dbActionGameService;

    public ScoresService(
        IHumanService humanService, 
        IDbActionService dbActionService, IDbActionScoreTableService dbActionScoreTableService, 
        IDbActionGameService dbActionGameService)
    {
        _humanService = humanService;
        _dbActionService = dbActionService;
        _dbActionScoreTableService = dbActionScoreTableService;
        _dbActionGameService = dbActionGameService;
    }

    public async Task TableScoreInitialize(Game game)
    {
        try
        {
            bool isReg = await _dbActionScoreTableService.IsRegisterByPlayerName(game.Player.Name);
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
            await _dbActionService.InsertAsync(scoreTable);
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
            int scoreTableId = await _dbActionScoreTableService.GetScoresTableIdByPlayerNameAsync(game.Player.Name);
            if (game.IsComputer)
            {
                if (game.Easy)
                {
                    var vsComputerEasy = await _dbActionScoreTableService.GetTotalGamesByScoreTableIdAsync<TotalGamesEasyModel>(scoreTableId);
                    _ = game.Player.StartFirst == true ? vsComputerEasy.StartFirst += 1 : vsComputerEasy.StartSecond += 1;
                    vsComputerEasy.TotalGames += 1;
                    await _dbActionService.UpdateAsync(vsComputerEasy);
                }
                if (game.Intermediate)
                {
                    TotalGamesIntermediateModel vsComputerIntermediate = new();
                    vsComputerIntermediate = (TotalGamesIntermediateModel)await _dbActionScoreTableService.GetTotalGamesByScoreTableIdAsync(vsComputerIntermediate, scoreTableId);
                    _ = game.Player.StartFirst == true ? vsComputerIntermediate.StartFirst += 1 : vsComputerIntermediate.StartSecond += 1;
                    vsComputerIntermediate.TotalGames += 1;
                    await _dbActionService.UpdateAsync(vsComputerIntermediate);
                }
                if (game.Hard)
                {
                    TotalGamesHardModel vsComputerHard = new();
                    vsComputerHard = (TotalGamesHardModel)await _dbActionScoreTableService.GetTotalGamesByScoreTableIdAsync(vsComputerHard, scoreTableId);
                    _ = game.Player.StartFirst == true ? vsComputerHard.StartFirst += 1 : vsComputerHard.StartSecond += 1;
                    vsComputerHard.TotalGames += 1;
                    await _dbActionService.UpdateAsync(vsComputerHard);
                }
            }
            else
            {
                TotalGamesVsHumanModel vsHumanModel = new();
                vsHumanModel = (TotalGamesVsHumanModel)await _dbActionScoreTableService.GetTotalGamesByScoreTableIdAsync(vsHumanModel, scoreTableId);
                _ = game.Player.StartFirst == true ? vsHumanModel.StartFirst += 1 : vsHumanModel.StartSecond += 1;
                await _dbActionService.UpdateAsync(vsHumanModel);
            }
            Task.CompletedTask.Wait();
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
            (winner.PlayerName1, winner.PlayerName2) = await _dbActionGameService.GetPlayersGameByGameIdAsync(winner.GameId);
            if (winner.State.ToLower() != GameState.Tie.ToString().ToLower())
            {
                _ = winner.WinnerName == winner.PlayerName1 ? winner.LoserName = winner.PlayerName2 : winner.LoserName = winner.PlayerName1;
            }
            await _humanService.SetScoresTableFinishedGame(winner);
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

