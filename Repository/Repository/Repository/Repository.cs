using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _dbContext;

    public Repository(DbContext dbContext)
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

    public Task InsertRangeAsync(TEntity entity, TEntity entity1)
    {
        throw new NotImplementedException();
    }
    public Task UpdateRangeAsync(TEntity entity, TEntity entity1)
    {
        throw new NotImplementedException();
    }
}
