namespace Games.Core.Services;

public interface IInitializeService
{
    Task<InitializeGameResponse> Initialize(InitializeGameRequest initializeGame);
}