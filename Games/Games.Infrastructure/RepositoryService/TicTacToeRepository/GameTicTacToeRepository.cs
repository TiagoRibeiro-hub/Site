using Games.Data;
using Games.Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public Task<TEntity> GetAnyByIdAsync<TEntity>(Expression<Func<int, TEntity>> expression) where TEntity : class
    {
        throw new NotImplementedException(); 
    }


}

