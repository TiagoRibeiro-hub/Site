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
        using (IDbContextTransaction transaction = _db.Database.BeginTransaction())
        {
            try
            {
                await _db.Set<TEntity>().AddAsync(entity);
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return entity.GetEntityKeyValue();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception();
            }
        }
    }
    public async Task InsertAsync<TEntity, T>(TEntity entity) where TEntity : class
    {
        try
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public Task InsertAsyncAsync<TEntity>(TEntity entity) where TEntity : class
    {
        throw new NotImplementedException();
    }
    public Task InsertRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        throw new NotImplementedException();
    }
    public Task UpdateRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class
    {
        throw new NotImplementedException();
    }

}
