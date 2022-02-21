using Games.Data;
using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public class RegisteredPlayersWrite : Repository<RegisteredPlayersEntity>, IRegisteredPlayersWrite
{
    public RegisteredPlayersWrite(RegisteredPlayersDbContext dbContext) : base(dbContext)
    {

    }

    public RegisteredPlayersDbContext RegisteredPlayersDb
    {
        get { return _dbContext as RegisteredPlayersDbContext; }
    }
}
