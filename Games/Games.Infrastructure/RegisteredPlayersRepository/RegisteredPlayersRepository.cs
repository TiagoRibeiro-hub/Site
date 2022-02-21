using Games.Data;

namespace Games.Infrastructure;

public class RegisteredPlayersRepository : IRegisteredPlayersRepository
{
    public RegisteredPlayersDbContext _dbContext;
    public RegisteredPlayersRepository(RegisteredPlayersDbContext dbContext)
    {
        _dbContext = dbContext;
        RegisteredPlayersWrite = new RegisteredPlayersWrite(_dbContext);
        RegisteredPlayersRead = new RegisteredPlayersRead(_dbContext);
    }
    public IRegisteredPlayersWrite RegisteredPlayersWrite { get; private set; }
    public IRegisteredPlayersRead RegisteredPlayersRead { get; private set; }

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