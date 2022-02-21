using System.Linq.Expressions;

namespace Repository;

public interface IReadRepository<TEntity> where TEntity : class
{
    Task<bool> IsAnyAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> FindAsync(int id);
    Task<IEnumerable<TEntity>> GetTableByAsync(Expression<Func<TEntity, bool>> expressionWhere);
    Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> expressionWhere, Expression<Func<TEntity, TResult>> expressionSelect)
        where TResult : IConvertible;
    Task<List<TResult>> GetToListAsync<TResult>(Expression<Func<TEntity, bool>> expressionWhere, Expression<Func<TEntity, TResult>> expressionSelect)
        where TResult : IConvertible;
}
