namespace Games.Core.Services;
public class GameService : IGameService
{
    private readonly IGameTicTacToeService _gameTicTacToeService;

    public GameService(IGameTicTacToeService gameTicTacToeService)
    {
        _gameTicTacToeService = gameTicTacToeService;
    }

    public async Task<GameVsComputerResponse> InitializeGameVsComputer(RegisterVsComputer request, GameType gameType)
    {
        if (gameType == GameType.TicTacToe)
        {
            return await _gameTicTacToeService.InitializeGameVsComputer(request);
        }

        return null;
    }
    public async Task<GameResponse> InitializeGameVsHuman(RegisterVsHuman request, GameType gameType)
    {
        if (gameType == GameType.TicTacToe)
        {
            return await _gameTicTacToeService.InitializeGameVsHuman(request);
        }

        return null;
    }
}

