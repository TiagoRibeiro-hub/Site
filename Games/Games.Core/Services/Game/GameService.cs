using Games.Infrastructure;
using Repository;

namespace Games.Core.Services;
public class GameService : IGameService
{
    private readonly IRegisterPlayerService _registerPlayerService;
    private readonly IInitializeService _initializeService;

    public GameService(
        IRegisterPlayerService registerPlayerService, 
        IInitializeService initializeService)
    {
        _registerPlayerService = registerPlayerService;
        _initializeService = initializeService;
    }

    public async Task<Response?> RegisterPlayer(RegisterPlayerRequest registerPlayer)
    {
        Response<RegisterPlayerResponse> response = new();
        if (registerPlayer == null)
        {
            return response.Fail(content: new Error(message: ApiSharedConst.RequestIsNull));
        }
        return await _registerPlayerService.RegisterPlayer(registerPlayer);
    }
    public async Task<Response?> Initialize(InitializeGameRequest initializeGame)
    {
        Response<InitializeGameResponse> response = new();
        if (initializeGame == null)
        {
            return response.Fail(content: new Error(message: ApiSharedConst.RequestIsNull));
        }
        InitializeGameResponse initializeGameResponse = await _initializeService.Initialize(initializeGame);
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
