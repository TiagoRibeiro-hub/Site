using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public class DbActionService : IDbActionService
{
    private readonly TicTacToeDbContext _db;
    

    public DbActionService(TicTacToeDbContext db)
    {
        _db = db;
    }

    public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task InsertRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class
    {
        try
        {
            await _db.Set<TEntity>().AddRangeAsync(entity, entity1);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task UpdateRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class
    {
        try
        {
            _db.Set<TEntity>().UpdateRange(entity, entity1);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
#nullable disable
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
}

