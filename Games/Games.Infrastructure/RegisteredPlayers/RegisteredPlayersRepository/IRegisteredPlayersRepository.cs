namespace Games.Infrastructure;

public interface IRegisteredPlayersRepository
{
    Task<bool> IsExistByEmail(string email);
    Task<bool> IsExistByPlayerName(string playerName);
    Task InsertAsync(RegisteredPlayersEntity registeredPlayersEntity);
}