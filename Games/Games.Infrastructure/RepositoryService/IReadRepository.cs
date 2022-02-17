using System.Linq.Expressions;
namespace Games.Infrastructure.RepositoryService;
public interface IReadRepository
{
    Task<bool> IsAnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
    Task<TEntity> FindAsync<TEntity>(int id) where TEntity : class;
    Task<IQueryable<TEntity>> GetTableByAsync<TEntity>(Expression<Func<TEntity, bool>> expressionWhere) where TEntity : class;
    Task<TResult> GetSelectedTableAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> expressionWhere, Expression<Func<TEntity, TResult>> expressionSelect) 
        where TEntity : class
        where TResult : IConvertible;

    Task<List<TResult>> GetSelectedTableToListAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> expressionWhere, Expression<Func<TEntity, TResult>> expressionSelect)
        where TEntity : class
        where TResult : IConvertible;
}

