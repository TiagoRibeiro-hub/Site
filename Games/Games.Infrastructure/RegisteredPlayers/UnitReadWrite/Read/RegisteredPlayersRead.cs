namespace Games.Infrastructure;
#nullable disable
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