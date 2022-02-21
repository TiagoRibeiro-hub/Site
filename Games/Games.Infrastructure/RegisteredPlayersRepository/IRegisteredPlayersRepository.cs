namespace Games.Infrastructure;

public interface IRegisteredPlayersRepository : IDisposable
{
    IRegisteredPlayersWrite RegisteredPlayersWrite { get; }
    IRegisteredPlayersRead RegisteredPlayersRead { get; }

    Task Complete();
}
