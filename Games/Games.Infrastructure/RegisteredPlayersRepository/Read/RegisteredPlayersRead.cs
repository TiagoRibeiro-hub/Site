using Games.Data;
using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public class RegisteredPlayersRead : ReadRepository<RegisteredPlayersEntity>, IRegisteredPlayersRead
{
    public RegisteredPlayersRead(RegisteredPlayersDbContext dbContext) : base(dbContext)
    {

    }

    public RegisteredPlayersDbContext RegisteredPlayersDb
    {
        get { return _dbContext as RegisteredPlayersDbContext; }
    }
}