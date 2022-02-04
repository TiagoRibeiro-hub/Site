
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
            int gameId = await _gameDbService.InsertInitializeGame(model);
            Task.CompletedTask.Wait();
            return gameId;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }

    }
    private async Task<bool> TableScoreInitialize(Human player)
    {
        try
        {
            bool isReg = _scoreDbService.IsRegisterByEmail(player.Email);
            if (!isReg)
            {
                await _scoreService.SetScoresTableAsync(player);
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
            bool isReg = await TableScoreInitialize(player);
            if (isReg)
            {
                await _scoreService.ScoresTableVsHumanAsync(player.Email);
            }
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task TableScoreInitializeVsComputer(Human player, string difficulty)
    {
        try
        {
            bool isReg = await TableScoreInitialize(player);
            if (isReg)
            {
                await _scoreService.ScoresTableVsComputerAsync(player.Email, difficulty);
            }
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}

