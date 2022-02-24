using Games.Core.Validatons;

namespace Games.Core.Services;
#nullable disable
public class GamePhasesService : IGamePhasesService
{
    private readonly IValidationService _validationService;
    private readonly IRegisterPlayerPhaseService _registerPlayerPhaseService;
    private readonly IInitializePhaseService _initializePhaseService;

    public GamePhasesService(
        IValidationService validationService,
        IRegisterPlayerPhaseService registerPlayerService, IInitializePhaseService initializeService)
    {
        _validationService = validationService;
        _registerPlayerPhaseService = registerPlayerService;
        _initializePhaseService = initializeService;
    }

    public async Task<Response> RegisterPlayer(RegisterPlayerRequest registerPlayer)
    {
        var validation = await _validationService.ValidateRegisterPlayerRequest(registerPlayer);
        if (!validation.IsValid)
        {
            return await _validationService.GetErrors(validation);
        }
        return await _registerPlayerPhaseService.RegisterPlayer(registerPlayer);
    }
    public async Task<Response> Initialize(InitializeGameRequest initializeGame)
    {
        var validation = await _validationService.InitializeGameRequestValidator(initializeGame);
        if (!validation.IsValid)
        {
            return await _validationService.GetErrors(validation);
        }   
        InitializeGameResponse initializeGameResponse = await _initializePhaseService.Initialize(initializeGame);
        Response<InitializeGameResponse> response = new();
        if (initializeGameResponse is null)
        {
            return response.Fail(ApiSharedConst.SomethingWentWrong); // Error come from DataBase 
        }
        return response.Success
        (
            content: initializeGameResponse,
            message: ApiSharedConst.EverthingOk
        );
    }

#nullable enable
    public Task<Response?> Play<TEntity>(TEntity playRequest) where TEntity : class
    {
        if (playRequest.GetType() == typeof(Request<PlayTicTacToeRequest>))
        {

        }
        //    Response<PlayResponse> response = new();
        //if (playRequest == null)
        //{
        //    //return response.Fail(content: new Error(message: ApiSharedConst.RequestIsNull));
        //}
        //return response.Fail(content: new Error(message: ApiSharedConst.RequestIsNull));
        //if (int.Parse(game.MoveTo) < 1 || int.Parse(game.MoveTo) > 9)
        //{
        //    return Task.FromResult(responseError.Fail("Possible moves between 1 & 9"));
        //}
        //if (game.PossibleMoves.ContainsValue(game.MoveTo) == false)
        //{
        //    return Task.FromResult(responseError.Fail($"{game.MoveTo} has already been played"));
        //}
        throw new NotImplementedException();
    }
}
