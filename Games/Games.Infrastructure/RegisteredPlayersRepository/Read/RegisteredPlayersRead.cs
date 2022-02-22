using Games.Data;
using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public class RegisteredPlayersRead<TEntity> : ReadRepository<TEntity>, IRegisteredPlayersRead<TEntity> where TEntity : class
{
    public RegisteredPlayersRead(RegisteredPlayersDbContext dbContext) : base(dbContext)
    {

    }

    public RegisteredPlayersDbContext RegisteredPlayersDb
    {
        get { return _dbContext as RegisteredPlayersDbContext; }
    }
}