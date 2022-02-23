using Games.Infrastructure;

namespace Games.Core.Services;

public class InitializeService : IInitializeService
{
    private readonly IGameTicTacToeService _gameTicTacToeService;

    public InitializeService(IGameTicTacToeService gameTicTacToeService)
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
            return null;
        }
        return initializeGameResponse;
    }
}
