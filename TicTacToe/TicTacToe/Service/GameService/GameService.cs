
using Microsoft.EntityFrameworkCore.Storage;
using TicTacToe.Data;
namespace TicTacToe.Service;
public class GameService : IGameService
{
    private readonly TicTacToeDbContext _db;
    private readonly IScoreService _scoreService;
    public GameService(TicTacToeDbContext db, IScoreService scoreService)
    {
        _db = db;
        _scoreService = scoreService;
    }

    public async Task InitializeGame(Human player1, Human player2, Computer computer)
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

            await _db.AddAsync(model);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }

    }
    private async Task<bool> TableScoreInitialize(Human player, string difficulty = "")
    {
        try
        {
            bool isReg = _scoreService.IsRegisterByEmail(player.Email);
            ScoresTableModel model = new();
            if (!isReg)
            {
                await SetScoresTableAsync(player);
                await SetTotalGamesVsComputerTableAsync(player.Email, difficulty);
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
    private async Task SetScoresTableAsync(Human player)
    {
        try
        {
            ScoresTableModel model = new();
            model.PlayerName = player.Name;
            model.TotalGames = 1;
            model.Email = player.Email;
            model.TotalGamesVsHuman = 1;
            await _db.ScoresTable.AddAsync(model);
            await _db.SaveChangesAsync();

            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }

    }
    private async Task SetTotalGamesVsComputerTableAsync(string email, string difficulty = "")
    {
        try
        {
            var id = _scoreService.GetScoreTableIdByEmail(email);
            if (id >= 0)
            {
                TotalGamesVsComputerModel totalGamesVsComputer = new();
                totalGamesVsComputer.ScoreTableId = id;
                if (difficulty != "")
                {
                    totalGamesVsComputer.TotalGames = 1;
                    if (difficulty == Difficulty.Easy.ToString())
                    {
                        totalGamesVsComputer.TotalGamesEasy = 1;
                    }
                    if (difficulty == Difficulty.Intermediate.ToString())
                    {
                        totalGamesVsComputer.TotalGamesIntermediate = 1;
                    }
                    if (difficulty == Difficulty.Hard.ToString())
                    {
                        totalGamesVsComputer.TotalGamesHard = 1;
                    }
                }
                await _db.TotalGamesVsComputer.AddAsync(totalGamesVsComputer);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
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
            bool isReg = await TableScoreInitialize(player, difficulty);
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

