using System.Linq.Expressions;
namespace Games.Infrastructure.RepositoryService;
public interface IReadRepository
{
    Task<bool> IsAnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
    Task<TEntity> GetAnyByIdAsync<TEntity>(Expression<Func<int, TEntity>> expression) where TEntity : class;
}

