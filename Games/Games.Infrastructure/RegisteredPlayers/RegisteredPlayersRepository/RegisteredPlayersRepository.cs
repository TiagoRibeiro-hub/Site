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
        Expression<Func<RegisteredPlayersEntity, bool>> predicate = x => x.PlayerEmail == email;
        return await _unitOfWorkRegisteredPlayers.RegisteredPlayersRead.IsAnyAsync(predicate);
    }

    public async Task<bool> IsExistByPlayerName(string playerName)
    {
        Expression<Func<RegisteredPlayersEntity, bool>> predicate = x => x.PlayerName == playerName;
        return await _unitOfWorkRegisteredPlayers.RegisteredPlayersRead.IsAnyAsync(predicate);
    }

    public async Task InsertAsync(RegisteredPlayersEntity registeredPlayersEntity)
    {
        await _unitOfWorkRegisteredPlayers.RegisteredPlayersWrite.InsertAsync(registeredPlayersEntity);
        await _unitOfWorkRegisteredPlayers.Complete();
    }
}
