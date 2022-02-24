namespace Games.Core.Services;

public interface IGamePhasesService
{
    Task<Response?> RegisterPlayer(RegisterPlayerRequest registerPlayer); 
    Task<Response?> Initialize(InitializeGameRequest initializeGame);
    Task<Response?> Play<TEntity>(TEntity playRequest) where TEntity : class;
}
