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
        if (GameType.TicTacToe.GetGameType(request.GameType))
        {
            return await _gameTicTacToeService.InitializeGameVsHumanAsync(request);
        }
        return null;
    }
    public Task<ResponseError> MoveValidation(GameVsHumanRequest game)
    {
        ResponseError responseError = new();
        if (GameType.TicTacToe.GetGameType(game.GameType))
        {
            if (int.Parse(game.MoveTo) < 1 || int.Parse(game.MoveTo) > 9)
            {
                return Task.FromResult(responseError.Fail("Possible moves between 1 & 9"));
            }
            if (game.PossibleMoves.ContainsValue(game.MoveTo) == false)
            {
                return Task.FromResult(responseError.Fail($"{game.MoveTo} has already been played"));
            }
        }
        
        return Task.FromResult(responseError.NoErrors(ApiSharedConst.EverthingOk));
    }
    public async Task<GameResponse?> PlayVsHuman(GameVsHumanRequest request)
    {
        if (GameType.TicTacToe.GetGameType(request.GameType))
        {
            return await _gameTicTacToeService.PlayVsHumanAsync(request);
        }
        return null;
    }

    #endregion

    #region Computer

    public async Task<GameVsComputerResponse?> InitializeVsComputer(RegisterVsComputer request)
    {
        if (GameType.TicTacToe.GetGameType(request.GameType))
        {
            return await _gameTicTacToeService.InitializeGameVsComputerAsync(request);
        }
        return null;
    }
   
    public async Task<GameVsComputerResponse?> PlayVsComputer(GameVsComputerRequest request)
    {
        if (GameType.TicTacToe.GetGameType(request.GameType))
        {
            return await _gameTicTacToeService.PlayVsComputerAsync(request);
        }
        return null;
    }

    #endregion

}

