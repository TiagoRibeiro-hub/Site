using Data._DbContext;
using Data.Infrastructure.Infrastructure.Repository.Read;

namespace _02.Games.RegisterPlayer.Core.Repoitory;
public class RegisteredPlayersRead<TEntity> : ReadRepository<TEntity>, IRegisteredPlayersRead<TEntity> where TEntity : class
{
    public RegisteredPlayersRead(RegisteredPlayersDbContext dbContext) : base(dbContext)
    {

    }
}

public interface IRegisteredPlayersRead<TEntity> : IReadRepository<TEntity> where TEntity : class
{

}