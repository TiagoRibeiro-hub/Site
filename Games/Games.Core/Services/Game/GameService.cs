namespace Games.Core.Services;
public class GameService : IGameService
{
    private readonly IGameTicTacToeService _gameTicTacToeService;

    public GameService(IGameTicTacToeService gameTicTacToeService)
    {
        _gameTicTacToeService = gameTicTacToeService;
    }

    #region Human
    public async Task<GameResponse?> InitializeVsHuman(RegisterVsHuman request)
    {
        if (request.GameType.ToLower() == GameType.TicTacToe.ToString().ToLower())
        {
            return await _gameTicTacToeService.InitializeGameVsHumanAsync(request);
        }
        return null;
    }
    public Task<ResponseError> MoveValidation(GameVsHumanRequest game)
    {
        if (game.GameType.ToLower() == GameType.TicTacToe.ToString().ToLower())
        {
            if (int.Parse(game.MoveTo) < 1 || int.Parse(game.MoveTo) > 9)
            {
                return Task.FromResult(new ResponseError("Possible moves between 1 & 9", false));
            }
            if (game.PossibleMoves.ContainsValue(game.MoveTo) == false)
            {
                return Task.FromResult(new ResponseError($"{game.MoveTo} has already been played", false));
            }
        }
        return Task.FromResult(new ResponseError(true));
    }

    public async Task<GameResponse?> PlayVsHuman(GameVsHumanRequest request)
    {
        if (request.GameType.ToLower() == GameType.TicTacToe.ToString().ToLower())
        {
            return await _gameTicTacToeService.PlayVsHumanAsync(request);
        }
        return null;
    }

    #endregion

    #region Computer

    public async Task<GameVsComputerResponse?> InitializeVsComputer(RegisterVsComputer request)
    {
        if (request.GameType.ToLower() == GameType.TicTacToe.ToString().ToLower())
        {
            return await _gameTicTacToeService.InitializeGameVsComputerAsync(request);
        }
        return null;
    }
   
    public async Task<GameVsComputerResponse?> PlayVsComputer(GameVsComputerRequest request)
    {
        if (request.GameType.ToLower() == GameType.TicTacToe.ToString().ToLower())
        {
            return await _gameTicTacToeService.PlayVsComputerAsync(request);
        }
        return null;
    }

    #endregion

}

