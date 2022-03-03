namespace _00.Infrastructure.Repository.Write;

public interface IWriteRepository<TEntity> where TEntity : class
{
    Task InsertAsync(TEntity entity);
    Task<int> InsertAndGetIdAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);

    Task InsertRangeAsync(TEntity entity, TEntity entity1);
    Task UpdateRangeAsync(TEntity entity, TEntity entity1);
}