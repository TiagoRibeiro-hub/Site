using _00.Game.Initialize.Data._DbContext;
using Data.Infrastructure.Infrastructure.Repository.Read;
using Data.Infrastructure.Infrastructure.Repository.Write;

namespace _02.Game.Initialize.Core.Repository.ReadWrite;

public class InitializeGameWrite<TEntity> : WriteRepository<TEntity>, IInitializeGameWrite<TEntity> where TEntity : class
{
    public InitializeGameWrite(InitializeGameDbContext dbContext) : base(dbContext)
    {

    }
}

public interface IInitializeGameWrite<TEntity> : IWriteRepository<TEntity> where TEntity : class
{
}