using Data._DbContext;
using Data.Infrastructure.Data._Entities;

namespace _02.Games.RegisterPlayer.Core.Repoitory;

public class RegisteredPlayersRepository : IRegisteredPlayersRepository
{
    public RegisteredPlayersDbContext _dbContext;
    public RegisteredPlayersRepository(RegisteredPlayersDbContext dbContext)
    {
        _dbContext = dbContext;
        RegisteredPlayersWrite = new RegisteredPlayersWrite<RegisteredPlayersEntity>(_dbContext);
        RegisteredPlayersRead = new RegisteredPlayersRead<RegisteredPlayersEntity>(_dbContext);
    }
    public IRegisteredPlayersWrite<RegisteredPlayersEntity> RegisteredPlayersWrite { get; private set; }
    public IRegisteredPlayersRead<RegisteredPlayersEntity> RegisteredPlayersRead { get; private set; }

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
        GC.SuppressFinalize(this);
    }
}