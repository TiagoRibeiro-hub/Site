using Games.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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

public static class RepositoryExtension
{
    public static int GetEntityKeyValue<TEntity>(this TEntity entity) where TEntity : class
    {
        int ret = 0;
        PropertyInfo key = typeof(TEntity).GetProperties().FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length != 0);
        if (key != null)
        {
            ret = (int)key.GetValue(entity, null);
            if (ret > 0)
            {
                return ret;
            }
        }
        throw new Exception();
    }
}