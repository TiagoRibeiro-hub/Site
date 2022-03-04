using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Infrastructure.Infrastructure.Repository.Write;
public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _dbContext;

    public WriteRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InsertAsync(TEntity entity)
    {
        try
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public async Task<int> InsertAndGetIdAsync(TEntity entity)
    {
        using IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
        try
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
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
    public Task UpdateAsync(TEntity entity)
    {
        try
        {
            _dbContext.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public async Task InsertRangeAsync(TEntity entity, TEntity entity1)
    {
        try
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entity, entity1);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public async Task UpdateRangeAsync(TEntity entity, TEntity entity1)
    {
        try
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}