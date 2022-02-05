
using Microsoft.EntityFrameworkCore.Storage;
using TicTacToe.Data;
namespace TicTacToe.Service;
public class GameService : IGameService
{
    private readonly IScoreService _scoreService;
    private readonly IScoreDbService _scoreDbService;
    private readonly IGameDbService _gameDbService;
    public GameService(IScoreService scoreService, IScoreDbService scoreDbService, IGameDbService gameDbService)
    {
        _scoreService = scoreService;
        _scoreDbService = scoreDbService;
        _gameDbService = gameDbService;
    }

    public async Task<int> InitializeGame(Human player1, Human player2, Computer computer)
    {
        try
        {
            GameModel model = new()
            {
                Player1_Name = player1.Name,
            };
            if (computer.Active)
            {
                model.Player2_Name = computer.Name;
                model.IsComputer = true;
                model.Difficulty = computer.Difficulty;
            }
            else
            {
                model.Player2_Name = player2.Name;
            }
            if (player1.StartFirst)
            {
                model.StartFirst = player1.Name;
            }
            if (player2.StartFirst)
            {
                model.StartFirst = player2.Name;
            }
            if (computer.StartFirst)
            {
                model.StartFirst = computer.Name;
            }
            int gameId = await _gameDbService.InsertInitializeGame(model);
            Task.CompletedTask.Wait();
            return gameId;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }

    }
    private async Task<bool> TableScoreInitializeHuman(Human human)
    {
        try
        {
            bool isReg = _scoreDbService.IsRegisterByEmail(human.Email);
            if (!isReg)
            {
                await _scoreService.SetScoresTableHumanAsync(human);
            }

            Task.CompletedTask.Wait();
            return isReg;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    private async Task<bool> TableScoreInitializeComputer(Computer computer)
    {
        try
        {
            bool isReg = _scoreDbService.IsRegisterByEmail(computer.Name);
            if (!isReg)
            {
                //await _scoreService.SetScoresTableComputerAsync(computer);
            }

            Task.CompletedTask.Wait();
            return isReg;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task TableScoreInitializeVsHuman(Human player)
    {
        try
        {
            bool isReg = await TableScoreInitializeHuman(player);
            if (isReg)
            {
                await _scoreService.ScoresTableVsHumanAsync(player.Email, player.StartFirst);
            }
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task TableScoreInitializeVsComputer(Human player, Computer computer)
    {
        try
        {
            bool isRegP = await TableScoreInitializeHuman(player);
            if (isRegP)
            {
                await _scoreService.ScoresTableVsComputerAsync(player.Email, player.StartFirst, computer.Difficulty);
            }
            bool isRegC = await TableScoreInitializeComputer(computer);
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}

