using TicTacToe.Data;

namespace TicTacToe.Service;
public class ScoreService : IScoreService
{
    private readonly TicTacToeDbContext _db;

    public ScoreService(TicTacToeDbContext db)
    {
        _db = db;
    }

    private int SetTotalGames(int totalGames)
    {
        return totalGames + 1;
    }

    private int SetTotalGamesVsHuman(int totalGamesVsHuman)
    {
        return totalGamesVsHuman + 1;
    }

    public Task<ScoresTableModel> ScoresTableVsHumanAsync(string email)
    {
        try
        {
            ScoresTableModel model = new();
            var p = _db.ScoresTable.Select(x => new
            {
                x.Email,
                x.PlayerName,
                x.Victories,
                x.Losses,
                x.Ties,
                x.TotalGames,
                x.TotalGamesVsHuman,

            }).Where(x => x.Email == email);

            foreach (var item in p)
            {
                model.Email = item.Email;
                model.PlayerName = item.PlayerName;
                model.Victories = item.Victories;
                model.Losses = item.Losses;
                model.Ties = item.Ties;
                model.TotalGames = SetTotalGames(item.TotalGames);
                model.TotalGamesVsHuman = SetTotalGamesVsHuman(item.TotalGamesVsHuman);
            }

            return Task.FromResult(model);
        }
        catch (Exception)
        {
            throw;
        }
    }
}

