using Games.Data;
using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public class RegisteredPlayersWrite<TEntity> : Repository<TEntity>, IRegisteredPlayersWrite<TEntity> where TEntity : class
{
    public RegisteredPlayersWrite(RegisteredPlayersDbContext dbContext) : base(dbContext)
    {

    }

    public RegisteredPlayersDbContext RegisteredPlayersDb
    {
        get { return _dbContext as RegisteredPlayersDbContext; }
    }
}
