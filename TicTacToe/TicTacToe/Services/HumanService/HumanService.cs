using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public class HumanService : IHumanService
{
    private readonly TicTacToeDbContext _db;
    private readonly IDbActionService _dbActionService;

    public HumanService(TicTacToeDbContext db, IDbActionService dbActionService)
    {
        _db = db;
        _dbActionService = dbActionService;
    }
    public async Task<TotalGamesVsHumanModel> GetTotalGamesVsHumanByScoreTableIdAsync(int scoreTableId)
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
    public async Task UpdateTotalGamesVsHumanAsync(TotalGamesVsHumanModel totalGamesVsHumanModel) 
    {
        try
        {
            await _dbActionService.UpdateAsync(totalGamesVsHumanModel);
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

}

