namespace Games.Core.Services;

public interface IInitializePhaseService
{
    Task<InitializeGameResponse> Initialize(InitializeGameRequest initializeGame);
}