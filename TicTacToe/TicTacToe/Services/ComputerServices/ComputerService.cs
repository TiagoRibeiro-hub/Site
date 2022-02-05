using TicTacToe.Data;
using TicTacToe.DbActionService;

namespace TicTacToe.Services;
public class ComputerService : IComputerService
{
    private readonly IDbActionGameService _dbActionGameService;
    public ComputerService(IDbActionGameService dbActionGameService)
    {
        _dbActionGameService = dbActionGameService;
    }
    public async Task TableScoreInitialize(Computer computer)
    {
        try
        {
            bool isReg = await _dbActionGameService.IsRegisterByPlayerName(computer.Name);
            if (!isReg)
            {
                await SetScoresTableInitializeAsync(computer);
            }
            else
            {
                //await UpdateScoreTableInitializeAsync(computer);
            }
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    private async Task SetScoresTableInitializeAsync(Computer computer)
    {
        try
        {
            ScoresTableModel scoreTable = new()
            {
                PlayerName = computer.Name,
                Email = computer.Email,
            };

            if (computer.Easy)
            {
                _ = computer.StartFirst == true ? scoreTable.TotalGamesVsComputer.TotalGamesEasy.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesEasy.StartSecond += 1;
                scoreTable.TotalGamesVsComputer.TotalGamesEasy.TotalGames += 1;

            }
            if (computer.Intermediate)
            {
                _ = computer.StartFirst == true ? scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.StartSecond += 1;
                scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.TotalGames += 1;
            }
            if (computer.Hard)
            {
                _ = computer.StartFirst == true ? scoreTable.TotalGamesVsComputer.TotalGamesHard.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesHard.StartSecond += 1;
                scoreTable.TotalGamesVsComputer.TotalGamesHard.TotalGames += 1;
            }
            await _dbActionGameService.InsertScoresTableAsync(scoreTable);
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

