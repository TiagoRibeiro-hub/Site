using Games.Infrastructure;
using Repository;

namespace Games.Core.Services;
public class GameService : IGameService
{
    private readonly IRegisteredPlayersRepository _unitOfWork;
    private readonly ITicTacToeService _ticTacToeService;
    public GameService(IRegisteredPlayersRepository unitOfWorkRegisteredPlayers, ITicTacToeService ticTacToeService)
    {
        _unitOfWork = unitOfWorkRegisteredPlayers;
        _ticTacToeService = ticTacToeService;
    }

    public async Task<Response?> RegisterPlayer(RegisterPlayerRequest registerPlayer)
    {
        Response<RegisterPlayerResponse> response = new();
        if (registerPlayer == null)
        {
            return response.Fail(content: new Error(message: ApiSharedConst.RequestIsNull));
        }
        bool isEmailRegistered, isPlayerNameRegistered;  
        isEmailRegistered = await _unitOfWork.RegisteredPlayersRead.IsAnyAsync(Expr.IsExistByEmail(registerPlayer.Player.Email));
        isPlayerNameRegistered = await _unitOfWork.RegisteredPlayersRead.IsAnyAsync(Expr.IsExistByPlayerName(registerPlayer.Player.Name));
        if (isPlayerNameRegistered == false && isEmailRegistered == false)
        {
            await _unitOfWork.RegisteredPlayersWrite.InsertAsync(registerPlayer.SetRegisteredPlayers());
            await _unitOfWork.Complete();
            return response.Success
                        (
                            content: new RegisterPlayerResponse(playerName: true, email: true),
                            message: ApiSharedConst.EverthingOk
                        );
        }
        if (isPlayerNameRegistered && isEmailRegistered)
        {
            return response.Success
                        (
                            content: new RegisterPlayerResponse(playerName: isPlayerNameRegistered, email: isEmailRegistered),
                            message: "Already Registered"
                        );
        }
        return response.Fail(content: new RegisterPlayerResponse(playerName: isPlayerNameRegistered, email: isEmailRegistered));
    }

    public async Task<Response?> Initialize(InitializeGameRequest initializeGame)
    {
        Response<InitializeGameResponse> response = new();
        if (initializeGame == null)
        {
            return response.Fail(content: new Error(message: ApiSharedConst.RequestIsNull));
        }
        InitializeGameResponse initializeGameResponse = new();
        if (initializeGame.GameType.ToUpper() == GameType.TicTacToe.GameTypeToString())
        {
            initializeGameResponse = await _ticTacToeService.Initialize(initializeGame);
        }

        if (initializeGameResponse is null)
        {
            return response.Fail(content: new Error(message: ApiSharedConst.SomethingWentWrong));
        }
        return response.Success
        (
            content: initializeGameResponse,
            message: ApiSharedConst.EverthingOk
        );
    }

    public async Task<Response?> Play(PlayRequest playRequest)
    {
        Response<PlayResponse> response = new();
        if (playRequest == null)
        {
            return response.Fail(content: new Error(message: ApiSharedConst.RequestIsNull));
        }
        return response.Fail(content: new Error(message: ApiSharedConst.RequestIsNull));
        //if (int.Parse(game.MoveTo) < 1 || int.Parse(game.MoveTo) > 9)
        //{
        //    return Task.FromResult(responseError.Fail("Possible moves between 1 & 9"));
        //}
        //if (game.PossibleMoves.ContainsValue(game.MoveTo) == false)
        //{
        //    return Task.FromResult(responseError.Fail($"{game.MoveTo} has already been played"));
        //}
    }
}
