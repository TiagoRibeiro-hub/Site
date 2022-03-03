using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _00.Infrastructure.Repository.Read;
public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _dbContext;

    public ReadRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsAnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            bool isReg = await _dbContext.Set<TEntity>().AnyAsync(predicate);
            if (isReg)
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public async Task<TEntity> FindAsync(int id)
    {
        try
        {
            TEntity result = await _dbContext.Set<TEntity>().FindAsync(id);
            if (result is null)
            {
                throw new Exception();
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public async Task<IEnumerable<TEntity>> GetTableByAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
            if (result is null)
            {
                throw new Exception();
            }
            return (IEnumerable<TEntity>)result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector) where TResult : IConvertible
    {
        try
        {
            var result = await _dbContext.Set<TEntity>().Where(predicate).Select(selector).FirstOrDefaultAsync();
            if (result is null)
            {
                throw new Exception();
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public async Task<List<TResult>> GetToListAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector) where TResult : IConvertible
    {
        try
        {
            var result = await _dbContext.Set<TEntity>().Where(predicate).Select(selector).ToListAsync();
            if (result is null)
            {
                throw new Exception();
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}