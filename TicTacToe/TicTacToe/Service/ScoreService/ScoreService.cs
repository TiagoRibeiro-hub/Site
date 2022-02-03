using TicTacToe.Data;

namespace TicTacToe.Service;
public class ScoreService : IScoreService
{
    private readonly TicTacToeDbContext _db;

    public ScoreService(TicTacToeDbContext db)
    {
        _db = db;
    }

    private static int SetTotalGames(int totalGames)
    {
        return totalGames + 1;
    }

    public bool IsRegisterByEmail(string email)
    {
        bool isReg = _db.ScoresTable.Any(x => x.Email == email);
        if (isReg)
        {
            return true;
        }
        return false;
    }
    public int GetScoreTableIdByEmail(string email)
    {
        var res = _db.ScoresTable.Select(x => new { x.Id, x.Email }).Where(x => x.Email == email);
        if (res.Any())
        {
            return res.Select(x => x.Id).FirstOrDefault();
        }
        return -1;
    }
    public ScoresTableModel GetScoreTableByEmail(string email, bool isComputer = false, string difficulty = "")
    {
        ScoresTableModel model = new();
        var player = from scores in _db.ScoresTable
                     join pcScores in _db.TotalGamesVsComputer on scores.Id equals pcScores.ScoreTableId
                     where scores.Email == email
                     select new
                     {
                         scores.Id,
                         scores.Email,
                         scores.PlayerName,
                         scores.Victories,
                         scores.Losses,
                         scores.Ties,
                         scores.TotalGames,
                         scores.TotalGamesVsHuman,
                         // COMPUTER TOTAL
                         PcTotalGames = pcScores.TotalGames,
                         pcScores.TotalGamesEasy,
                         pcScores.TotalGamesIntermediate,
                         pcScores.TotalGamesHard
                     };

        foreach (var item in player)
        {
            model.Id = item.Id;
            model.Email = item.Email;
            model.PlayerName = item.PlayerName;
            model.Victories = item.Victories;
            model.Losses = item.Losses;
            model.Ties = item.Ties;
            model.TotalGames = SetTotalGames(item.TotalGames);
            // COMPUTER TOTAL
            if (isComputer)
            {
                model.TotalGamesVsComputer.TotalGames = SetTotalGames(item.PcTotalGames);
                if (difficulty == Difficulty.Easy.ToString())
                {
                    model.TotalGamesVsComputer.TotalGamesEasy = SetTotalGames(item.TotalGamesEasy);
                }
                if (difficulty == Difficulty.Intermediate.ToString())
                {
                    model.TotalGamesVsComputer.TotalGamesIntermediate = SetTotalGames(item.TotalGamesIntermediate);
                }
                if (difficulty == Difficulty.Hard.ToString())
                {
                    model.TotalGamesVsComputer.TotalGamesHard = SetTotalGames(item.TotalGamesHard);
                }
            }
            else
            {
                model.TotalGamesVsHuman = SetTotalGames(item.TotalGamesVsHuman);
            }
        }

        return model;
    }
    public async Task ScoresTableVsHumanAsync(string email)
    {
        try
        {
            ScoresTableModel model = GetScoreTableByEmail(email);
            _db.ScoresTable.Update(model);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public async Task ScoresTableVsComputerAsync(string email, string difficulty)
    {
        try
        {
            ScoresTableModel model = GetScoreTableByEmail(email, true, difficulty);
            _db.ScoresTable.Update(model);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

