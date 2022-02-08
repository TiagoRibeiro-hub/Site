using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;

namespace TicTacToe.DbActionService;
#nullable disable
public class DbActionScoreTableService : IDbActionScoreTableService
{
    private readonly TicTacToeDbContext _db;

    public DbActionScoreTableService(TicTacToeDbContext db)
    {
        _db = db;
    }

    public async Task<bool> IsRegisterByPlayerName(string playerName)
    {
        try
        {
            bool isReg = await _db.ScoresTable.AnyAsync(x => x.PlayerName == playerName);
            if (isReg)
            {
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public async Task<int> GetScoresTableIdByPlayerNameAsync(string playerName)
    {
        try
        {
            var res = await _db.ScoresTable.Select(x => new
            {
                x.Id,
                x.PlayerName
            }).Where(x => x.PlayerName == playerName).FirstOrDefaultAsync();

            if (res is null)
            {
                throw new Exception();
            }

            return res.Id;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task<object> GetTotalGamesScoreTableIdAsync<TEntity>(TEntity entity, int scoreTableId) where TEntity : class
    {
        try
        {
            object result = new();
            if (entity.GetType().Equals(typeof(TotalGamesVsHumanModel)))
            {
                result = await _db.TotalGamesVsHuman.FirstOrDefaultAsync(x => x.Id == scoreTableId);
            }
            if (entity.GetType().Equals(typeof(TotalGamesEasyModel)))
            {
                result = await _db.TotalGamesEasy.FirstOrDefaultAsync(x => x.Id == scoreTableId);
            }
            if (entity.GetType().Equals(typeof(TotalGamesIntermediateModel)))
            {
                result = await _db.TotalGamesIntermediate.FirstOrDefaultAsync(x => x.Id == scoreTableId);
            }
            if (entity.GetType().Equals(typeof(TotalGamesHardModel)))
            {
                result = await _db.TotalGamesHard.FirstOrDefaultAsync(x => x.Id == scoreTableId);
            }
            if (result is null)
            {
                throw new Exception();
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public Task<HashSet<ScoresTableModel>> GetTotalGamesVsHumanAsync(string playerName1, string playerName2)
    {
        try
        {
            HashSet<ScoresTableModel> scoresList = new();
            var result = from scores in _db.ScoresTable
                         join vsHuman in _db.TotalGamesVsHuman on scores.Id equals vsHuman.ScoreTableId
                         where scores.PlayerName == playerName1 || scores.PlayerName == playerName2
                         select new
                         {
                             scores.PlayerName,
                             scores.Email,
                             vsHuman.Id,
                             vsHuman.StartFirst,
                             vsHuman.StartSecond,
                             vsHuman.TotalGames,
                             vsHuman.Victories,
                             vsHuman.Losses,
                             vsHuman.Ties,
                             vsHuman.ScoreTableId,
                         };
            if (result is null)
            {
                throw new Exception();
            }

            foreach (var item in result)
            {
                ScoresTableModel scoresTable = new();
                scoresTable.PlayerName = item.PlayerName;
                scoresTable.Email = item.Email;
                scoresTable.TotalGamesVsHuman.Id = item.Id;
                scoresTable.TotalGamesVsHuman.StartFirst = item.StartFirst;
                scoresTable.TotalGamesVsHuman.StartSecond = item.StartSecond;
                scoresTable.TotalGamesVsHuman.TotalGames = item.TotalGames;
                scoresTable.TotalGamesVsHuman.Victories = item.Victories;
                scoresTable.TotalGamesVsHuman.Losses = item.Losses;
                scoresTable.TotalGamesVsHuman.Ties = item.Ties;
                scoresTable.TotalGamesVsHuman.ScoreTableId = item.ScoreTableId;
                scoresList.Add(scoresTable);
            }

            return Task.FromResult(scoresList);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public Task<ScoresTableModel> GetTotalGamesVsComputerAsync(string playerName1)
    {
        try
        {
            ScoresTableModel scoresTable = new();
            var result = from scores in _db.ScoresTable
                         join vsComputer in _db.TotalGamesVsComputer on scores.Id equals vsComputer.ScoreTableId
                         join easy in _db.TotalGamesEasy on vsComputer.ScoreTableId equals easy.TotalGamesVsComputerId
                         join intermediate in _db.TotalGamesIntermediate on vsComputer.ScoreTableId equals intermediate.TotalGamesVsComputerId
                         join hard in _db.TotalGamesHard on vsComputer.ScoreTableId equals hard.TotalGamesVsComputerId
                         where scores.PlayerName == playerName1
                         select new
                         {
                             scores.PlayerName,
                             scores.Email,
                             //TotalGamesVsComputer
                             vsComputer.Id,
                             vsComputer.ScoreTableId,
                             //TotalGamesVsComputerEasy
                             Easy_StartFirst = easy.StartFirst,
                             Easy_StartSecond = easy.StartSecond,
                             Easy_TotalGames = easy.TotalGames,
                             Easy_Victories = easy.Victories,
                             Easy_Losses = easy.Losses,
                             Easy_Ties = easy.Ties,
                             //TotalGamesVsComputerIntermediate
                             Intermediate_StartFirst = intermediate.StartFirst,
                             Intermediate_StartSecond = intermediate.StartSecond,
                             Intermediate_TotalGames = intermediate.TotalGames,
                             Intermediate_Victories = intermediate.Victories,
                             Intermediate_Losses = intermediate.Losses,
                             Intermediate_Ties = intermediate.Ties,
                             //TotalGamesVsComputerHard
                             Hard_StartFirst = hard.StartFirst,
                             Hard_StartSecond = hard.StartSecond,
                             Hard_TotalGames = hard.TotalGames,
                             Hard_Victories = hard.Victories,
                             Hard_Losses = hard.Losses,
                             Hard_Ties = hard.Ties
                         };
            if (result is null)
            {
                throw new Exception();
            }
            foreach (var item in result)
            {
                scoresTable.PlayerName = item.PlayerName;
                scoresTable.Email = item.Email;
                //TotalGamesVsComputer
                scoresTable.TotalGamesVsComputer.Id = item.Id;
                scoresTable.TotalGamesVsComputer.ScoreTableId = item.ScoreTableId;
                //Easy
                scoresTable.TotalGamesVsComputer.TotalGamesEasy.StartFirst = item.Easy_StartFirst;
                scoresTable.TotalGamesVsComputer.TotalGamesEasy.StartSecond = item.Easy_StartSecond;
                scoresTable.TotalGamesVsComputer.TotalGamesEasy.TotalGames = item.Easy_TotalGames;
                scoresTable.TotalGamesVsComputer.TotalGamesEasy.Victories = item.Easy_Victories;
                scoresTable.TotalGamesVsComputer.TotalGamesEasy.Losses = item.Easy_Losses;
                scoresTable.TotalGamesVsComputer.TotalGamesEasy.Ties = item.Easy_Ties;
                //Intermediate
                scoresTable.TotalGamesVsComputer.TotalGamesIntermediate.StartFirst = item.Intermediate_StartFirst;
                scoresTable.TotalGamesVsComputer.TotalGamesIntermediate.StartSecond = item.Intermediate_StartSecond;
                scoresTable.TotalGamesVsComputer.TotalGamesIntermediate.TotalGames = item.Intermediate_TotalGames;
                scoresTable.TotalGamesVsComputer.TotalGamesIntermediate.Victories = item.Intermediate_Victories;
                scoresTable.TotalGamesVsComputer.TotalGamesIntermediate.Losses = item.Intermediate_Losses;
                scoresTable.TotalGamesVsComputer.TotalGamesIntermediate.Ties = item.Intermediate_Ties;
                //Hard
                scoresTable.TotalGamesVsComputer.TotalGamesHard.StartFirst = item.Hard_StartFirst;
                scoresTable.TotalGamesVsComputer.TotalGamesHard.StartSecond = item.Hard_StartSecond;
                scoresTable.TotalGamesVsComputer.TotalGamesHard.TotalGames = item.Hard_TotalGames;
                scoresTable.TotalGamesVsComputer.TotalGamesHard.Victories = item.Hard_Victories;
                scoresTable.TotalGamesVsComputer.TotalGamesHard.Losses = item.Hard_Losses;
                scoresTable.TotalGamesVsComputer.TotalGamesHard.Ties = item.Hard_Ties;
            }
            return Task.FromResult(scoresTable);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

