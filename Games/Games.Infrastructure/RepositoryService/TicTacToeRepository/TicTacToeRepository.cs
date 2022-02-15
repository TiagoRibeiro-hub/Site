using Games.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Games.Infrastructure.RepositoryService;
public class TicTacToeRepository : IRepository
{
    private readonly TicTacToeDbContext _db;
    public TicTacToeRepository(TicTacToeDbContext db)
    {
        _db = db;
    }

    public async Task<int> InsertAndGetIdAsync<TEntity>(TEntity entity) where TEntity : class
    {
        using IDbContextTransaction transaction = _db.Database.BeginTransaction();
        try
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
            int gameId = entity.GetEntityKeyValue();
            await transaction.CommitAsync();
            return gameId;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception(ex.ToString());
        }
    }
    public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public async Task InsertRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class
    {
        try
        {
            await _db.Set<TEntity>().AddRangeAsync(entity, entity1);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public async Task UpdateRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class
    {
        try
        {
            _db.Set<TEntity>().UpdateRange(entity, entity1);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
