namespace Games.Infrastructure.RepositoryService;
public interface IRepository
{
    Task InsertAsync<TEntity, T>(TEntity entity) 
        where TEntity : class;
    Task InsertRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class;

    Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
    Task UpdateRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class;
}

