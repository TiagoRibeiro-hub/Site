using _00.Infrastructure.Repository.Read;
using _01.Games.Data._DbContext;

namespace _02.Games.Core.Repository;

public class RegisteredPlayersRead<TEntity> : ReadRepository<TEntity>, IRegisteredPlayersRead<TEntity> where TEntity : class
{
    public RegisteredPlayersRead(RegisteredPlayersDbContext dbContext) : base(dbContext)
    {

    }
}

public interface IRegisteredPlayersRead<TEntity> : IReadRepository<TEntity> where TEntity : class
{

}
