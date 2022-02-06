namespace TicTacToe.DbActionService;
public interface IDbActionService
{
    Task InsertAsync<TEntity>(TEntity entity) where TEntity : class;
    Task InsertRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class;

    Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;

}

