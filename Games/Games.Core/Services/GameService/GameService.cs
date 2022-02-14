namespace Games.Core.Services;
public class GameService : IGameService
{
    private readonly IGameTicTacToeService _gameTicTacToeService;

    public GameService(IGameTicTacToeService gameTicTacToeService)
    {
        _gameTicTacToeService = gameTicTacToeService;
    }

    public async Task<GameVsComputerResponse?> InitializeVsComputer(RegisterVsComputer request, string gameType)
    {
        if (gameType.ToLower() == GameType.TicTacToe.ToString().ToLower())
        {
            return await _gameTicTacToeService.InitializeGameVsComputer(request);
        }
        return null;
    }

    public async Task<GameResponse?> InitializeVsHuman(RegisterVsHuman request, string gameType)
    {
        if (gameType.ToLower() == GameType.TicTacToe.ToString().ToLower())
        {
            return await _gameTicTacToeService.InitializeGameVsHuman(request);
        }
        return null;
    }

}

