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
    public ScoresTableModel GetScoreTableByEmail(string email)
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
            model.TotalGames = item.TotalGames;
            model.TotalGamesVsHuman = item.TotalGamesVsHuman;
            // COMPUTER TOTAL
            model.TotalGamesVsComputer.TotalGames = item.PcTotalGames;
            model.TotalGamesVsComputer.TotalGamesEasy = item.TotalGamesEasy;
            model.TotalGamesVsComputer.TotalGamesIntermediate = item.TotalGamesIntermediate;
            model.TotalGamesVsComputer.TotalGamesHard = item.TotalGamesHard;
        }

        return model;
    }
    private async Task UpdateScoreTable(string email, bool isComputer = false, string difficulty = "")
    {
        var scoreTable = _db.ScoresTable.FirstOrDefault(x => x.Email == email);

        if (scoreTable is null)
        {
            throw new Exception();
        }

        scoreTable.TotalGames = SetTotalGames(scoreTable.TotalGames);
        if (!isComputer)
        {
            scoreTable.TotalGamesVsHuman = SetTotalGames(scoreTable.TotalGamesVsHuman);
            _db.ScoresTable.Update(scoreTable);
        }
        else
        {
            var totalGamesVsComputer = _db.TotalGamesVsComputer.FirstOrDefault(x => x.ScoreTableId == scoreTable.Id);
            if (totalGamesVsComputer is null)
            {
                throw new Exception();
            }
            totalGamesVsComputer.TotalGames = SetTotalGames(totalGamesVsComputer.TotalGames);
            if (difficulty == Difficulty.Easy.ToString())
            {
                totalGamesVsComputer.TotalGamesEasy = SetTotalGames(totalGamesVsComputer.TotalGamesEasy);
            }
            if (difficulty == Difficulty.Intermediate.ToString())
            {
                totalGamesVsComputer.TotalGamesIntermediate = SetTotalGames(totalGamesVsComputer.TotalGamesIntermediate);
            }
            if (difficulty == Difficulty.Hard.ToString())
            {
                totalGamesVsComputer.TotalGamesHard = SetTotalGames(totalGamesVsComputer.TotalGamesHard);
            }

            _db.TotalGamesVsComputer.Update(totalGamesVsComputer);
        }
        Task.CompletedTask.Wait();
    }
    public async Task ScoresTableVsHumanAsync(string email)
    {
        try
        {
            await UpdateScoreTable(email);
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
            await UpdateScoreTable(email, true, difficulty);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

