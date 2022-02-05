using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public class DbActionHumanService : IDbActionHumanService
{
    private readonly TicTacToeDbContext _db;

    public DbActionHumanService(TicTacToeDbContext db)
    {
        _db = db;
    }
    public async Task<TotalGamesVsHumanModel> GetScoresVsHumanByScoreTableIdAsync(int scoreTableId)
    {
        try
        {
            var totalGamesVsHuman = await _db.TotalGamesVsHuman.FirstOrDefaultAsync(x => x.Id == scoreTableId);
            if (totalGamesVsHuman is null)
            {
                throw new Exception();
            }
            return totalGamesVsHuman;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task UpdateScoresTableTotalGamesVsHumanAsync(TotalGamesVsHumanModel totalGamesVsHumanModel)
    {
        try
        {
            _db.TotalGamesVsHuman.Update(totalGamesVsHumanModel);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

}

