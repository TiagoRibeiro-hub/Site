namespace Games.Core.Services;

public interface ITicTacToeService
{
    Task<InitializeGameResponse> Initialize(InitializeGameRequest initializeGame);
    Task<Response?> Play(PlayRequest playRequest);
}