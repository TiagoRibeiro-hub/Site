using Games.Infrastructure;

namespace Games.Core.Services;

public class InitializePhaseService : IInitializePhaseService
{
    private readonly IGameTicTacToeService _gameTicTacToeService;

    public InitializePhaseService(IGameTicTacToeService gameTicTacToeService)
    {
        _gameTicTacToeService = gameTicTacToeService;
    }

    public async Task<InitializeGameResponse> Initialize(InitializeGameRequest initializeGame)
    {
        InitializeGameResponse initializeGameResponse = new();
        if (GameType.TicTacToe.GetGameType(initializeGame.GameType))
        {
            initializeGameResponse = await _gameTicTacToeService.Initialize(initializeGame);
        }
        if (GameType.TicTacToe.GetGameType(initializeGame.GameType))
        {
            // 
        }
        if (initializeGameResponse is null || initializeGameResponse.IdGame <= 0)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }
        return initializeGameResponse;
    }
}
