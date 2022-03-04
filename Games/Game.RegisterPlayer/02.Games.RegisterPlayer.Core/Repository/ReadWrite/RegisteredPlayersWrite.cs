using Data.Infrastructure.Infrastructure.Repository.Write;
using Microsoft.EntityFrameworkCore;

namespace _02.Games.RegisterPlayer.Core.Repoitory;

public class RegisteredPlayersWrite<TEntity> : WriteRepository<TEntity>, IRegisteredPlayersWrite<TEntity> where TEntity : class
{
    public RegisteredPlayersWrite(DbContext dbContext) : base(dbContext)
    {
    }
}

public interface IRegisteredPlayersWrite<TEntity> : IWriteRepository<TEntity> where TEntity : class
{

}