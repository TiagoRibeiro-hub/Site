using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository;

public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _dbContext;

    public ReadRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsAnyAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            bool isReg = await _dbContext.Set<TEntity>().AnyAsync(expression);
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

    public Task<TEntity> FindAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> expressionWhere, Expression<Func<TEntity, TResult>> expressionSelect) where TResult : IConvertible
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetTableByAsync(Expression<Func<TEntity, bool>> expressionWhere)
    {
        throw new NotImplementedException();
    }

    public Task<List<TResult>> GetToListAsync<TResult>(Expression<Func<TEntity, bool>> expressionWhere, Expression<Func<TEntity, TResult>> expressionSelect) where TResult : IConvertible
    {
        throw new NotImplementedException();
    }
}