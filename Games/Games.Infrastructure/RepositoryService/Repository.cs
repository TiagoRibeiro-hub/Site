using Games.Data;
using Microsoft.EntityFrameworkCore;

namespace Games.Infrastructure.RepositoryService;
public class Repository : IRepository
{
    public Task InsertAsync<TEntity, T>(TEntity entity) where TEntity : class
    {
        throw new NotImplementedException();
    }

    public Task InsertRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        throw new NotImplementedException();
    }

    public Task UpdateRangeAsync<TEntity>(TEntity entity, TEntity entity1) where TEntity : class
    {
        throw new NotImplementedException();
    }
}

