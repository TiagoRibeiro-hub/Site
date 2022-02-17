using Games.Data;
using Games.Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
#nullable disable
namespace Games.Infrastructure.RepositoryService;
public class GameTicTacToeRepository : IReadRepository
{
    private readonly TicTacToeDbContext _db;
    public GameTicTacToeRepository(TicTacToeDbContext db)
    {
        _db = db;
    }

    public async Task<bool> IsAnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
    {
        try
        {
            bool isReg = await _db.Set<TEntity>().AnyAsync(expression);
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
    public async Task<TEntity> FindAsync<TEntity>(int id) where TEntity : class
    {
        try
        {
            TEntity result = await _db.Set<TEntity>().FindAsync(id);
            if(result is null)
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
    public async Task<IQueryable<TEntity>> GetTableByAsync<TEntity>(Expression<Func<TEntity, bool>> expressionWhere) where TEntity : class
    {
        try
        {
            var result = await _db.Set<TEntity>().Where(expressionWhere).FirstOrDefaultAsync();
            if (result is null)
            {
                throw new Exception();
            }
            return result as IQueryable<TEntity>;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public async Task<TResult> GetSelectedTableAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> expressionWhere, Expression<Func<TEntity, TResult>> expressionSelect)
    where TEntity : class
    where TResult : IConvertible
    {
        try
        {
            var result = await _db.Set<TEntity>().Where(expressionWhere).Select(expressionSelect).FirstOrDefaultAsync();
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

    public async Task<List<TResult>> GetSelectedTableToListAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> expressionWhere, Expression<Func<TEntity, TResult>> expressionSelect)
        where TEntity : class
        where TResult : IConvertible
    {
        try
        {
            var result = await _db.Set<TEntity>().Where(expressionWhere).Select(expressionSelect).ToListAsync();
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

#nullable enable



}

