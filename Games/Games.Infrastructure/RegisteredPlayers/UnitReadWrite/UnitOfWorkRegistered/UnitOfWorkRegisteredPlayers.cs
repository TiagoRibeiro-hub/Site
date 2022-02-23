namespace Games.Infrastructure;

public class UnitOfWorkRegisteredPlayers<TEntity> : IUnitOfWorkRegisteredPlayers<TEntity> where TEntity : class
{
    public RegisteredPlayersDbContext _dbContext;
    public UnitOfWorkRegisteredPlayers(RegisteredPlayersDbContext dbContext)
    {
        _dbContext = dbContext;
        RegisteredPlayersWrite = new RegisteredPlayersWrite<TEntity>(_dbContext);
        RegisteredPlayersRead = new RegisteredPlayersRead<TEntity>(_dbContext);
    }
    public IRegisteredPlayersWrite<TEntity> RegisteredPlayersWrite { get; private set; }
    public IRegisteredPlayersRead<TEntity> RegisteredPlayersRead { get; private set; }

    public async Task Complete()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}