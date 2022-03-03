using System.Linq.Expressions;

namespace _00.Infrastructure.Repository.Read;

public interface IReadRepository<TEntity> where TEntity : class
{
    Task<bool> IsAnyAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> FindAsync(int id);
    Task<IEnumerable<TEntity>> GetTableByAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        where TResult : IConvertible;
    Task<List<TResult>> GetToListAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        where TResult : IConvertible;
}
