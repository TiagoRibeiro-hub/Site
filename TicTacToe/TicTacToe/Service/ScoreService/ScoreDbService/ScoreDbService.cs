using TicTacToe.Data;

namespace TicTacToe.Service;
public class ScoreDbService : IScoreDbService
{
    private readonly TicTacToeDbContext _db;

    public ScoreDbService(TicTacToeDbContext db)
    {
        _db = db;
    }
    
    public bool IsRegisterByEmail(string email)
    {
        try
        {
            bool isReg = _db.ScoresTable.Any(x => x.Email == email);
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
    public int GetScoreTableIdByEmail(string email)
    {
        try
        {
            var res = _db.ScoresTable.Select(x => new { x.Id, x.Email }).Where(x => x.Email == email);
            if (res.Any())
            {
                return res.Select(x => x.Id).FirstOrDefault();
            }
            return -1;
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public ScoresTableModel GetScoreTableByEmail(string email)
    {
        try
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
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public async Task InsertScoresTableAsync(ScoresTableModel model)
    {
        try
        {
            await _db.ScoresTable.AddAsync(model);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public async Task UpdateScoreTableAsync(string email, bool isComputer = false, string difficulty = "")
    {
        try
        {
            var scoreTable = _db.ScoresTable.FirstOrDefault(x => x.Email == email);

            if (scoreTable is null)
            {
                throw new Exception();
            }

            scoreTable.TotalGames = ScoresFuncs.SetTotalGames(scoreTable.TotalGames);
            if (!isComputer)
            {
                scoreTable.TotalGamesVsHuman = ScoresFuncs.SetTotalGames(scoreTable.TotalGamesVsHuman);
                _db.ScoresTable.Update(scoreTable);
            }
            else
            {
                var totalGamesVsComputer = _db.TotalGamesVsComputer.FirstOrDefault(x => x.ScoreTableId == scoreTable.Id);
                if (totalGamesVsComputer is null)
                {
                    throw new Exception();
                }
                totalGamesVsComputer.TotalGames = ScoresFuncs.SetTotalGames(totalGamesVsComputer.TotalGames);
                if (difficulty == Difficulty.Easy.ToString())
                {
                    totalGamesVsComputer.TotalGamesEasy = ScoresFuncs.SetTotalGames(totalGamesVsComputer.TotalGamesEasy);
                }
                if (difficulty == Difficulty.Intermediate.ToString())
                {
                    totalGamesVsComputer.TotalGamesIntermediate = ScoresFuncs.SetTotalGames(totalGamesVsComputer.TotalGamesIntermediate);
                }
                if (difficulty == Difficulty.Hard.ToString())
                {
                    totalGamesVsComputer.TotalGamesHard = ScoresFuncs.SetTotalGames(totalGamesVsComputer.TotalGamesHard);
                }

                _db.TotalGamesVsComputer.Update(totalGamesVsComputer);
            }
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }


}
