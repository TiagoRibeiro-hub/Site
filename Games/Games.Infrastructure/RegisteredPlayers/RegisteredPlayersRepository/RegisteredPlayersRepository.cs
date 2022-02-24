namespace Games.Infrastructure;
public class RegisteredPlayersRepository : IRegisteredPlayersRepository
{
    private readonly IUnitOfWorkRegisteredPlayers<RegisteredPlayersEntity> _unitOfWorkRegisteredPlayers;

    public RegisteredPlayersRepository(IUnitOfWorkRegisteredPlayers<RegisteredPlayersEntity> registeredPlayersRepository)
    {
        _unitOfWorkRegisteredPlayers = registeredPlayersRepository;
    }

    public async Task<bool> IsExistByEmail(string email)
    {
        try
        {
            Expression<Func<RegisteredPlayersEntity, bool>> predicate = x => x.PlayerEmail == email;
            return await _unitOfWorkRegisteredPlayers.RegisteredPlayersRead.IsAnyAsync(predicate);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public async Task<bool> IsExistByPlayerName(string playerName)
    {
        try
        {
            Expression<Func<RegisteredPlayersEntity, bool>> predicate = x => x.PlayerName == playerName;
            return await _unitOfWorkRegisteredPlayers.RegisteredPlayersRead.IsAnyAsync(predicate);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public async Task InsertAsync(RegisteredPlayersEntity registeredPlayersEntity)
    {
        try
        {
            await _unitOfWorkRegisteredPlayers.RegisteredPlayersWrite.InsertAsync(registeredPlayersEntity);
            await _unitOfWorkRegisteredPlayers.Complete();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
