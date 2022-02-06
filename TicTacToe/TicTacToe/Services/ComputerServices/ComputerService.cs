using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;
using TicTacToe.DbActionService;

namespace TicTacToe.Services;
public class ComputerService : IComputerService
{
    private readonly TicTacToeDbContext _db;
    private readonly IDbActionService _dbActionService;
    public ComputerService(TicTacToeDbContext db, IDbActionService dbActionService)
    {
        _db = db;
        _dbActionService = dbActionService;
    }

    public async Task<TotalGamesEasyModel> GetTotalGamesEasyByScoreTableIdAsync(int scoreTableId)
    {
        try
        {
            var totalGamesVsComputer = await _db.TotalGamesEasy.FirstOrDefaultAsync(x => x.Id == scoreTableId);
            if (totalGamesVsComputer is null)
            {
                throw new Exception();
            }
            return totalGamesVsComputer;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task<TotalGamesIntermediateModel> GetTotalGamesIntermediateByScoreTableIdAsync(int scoreTableId)
    {
        try
        {
            var totalGamesVsComputer = await _db.TotalGamesIntermediate.FirstOrDefaultAsync(x => x.Id == scoreTableId);
            if (totalGamesVsComputer is null)
            {
                throw new Exception();
            }
            return totalGamesVsComputer;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task<TotalGamesHardModel> GetTotalGamesHardByScoreTableIdAsync(int scoreTableId)
    {
        try
        {
            var totalGamesVsComputer = await _db.TotalGamesHard.FirstOrDefaultAsync(x => x.Id == scoreTableId);
            if (totalGamesVsComputer is null)
            {
                throw new Exception();
            }
            return totalGamesVsComputer;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }


    public async Task UpdateTotalGamesVsComputerAsync<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            await _dbActionService.UpdateAsync(entity);
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}

