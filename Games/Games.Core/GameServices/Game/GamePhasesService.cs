using Games.Core.Validatons;

namespace Games.Core.Services;
#nullable disable
public class GamePhasesService : IGamePhasesService
{
    private readonly IValidationService _validationService;
    private readonly IRegisterPlayerPhaseService _registerPlayerPhaseService;
    private readonly IInitializePhaseService _initializePhaseService;
    private readonly IPlayPhaseService _playPhaseService;
    public GamePhasesService(
        IValidationService validationService, IRegisterPlayerPhaseService registerPlayerService, 
        IInitializePhaseService initializeService, IPlayPhaseService playPhaseService)
    {
        _validationService = validationService;
        _registerPlayerPhaseService = registerPlayerService;
        _initializePhaseService = initializeService;
        _playPhaseService = playPhaseService;
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
    public async Task<Response?> Play(PlayRequest playRequest)
    {
        var validation = await _validationService.PlayRequestValidator(playRequest);
        if (!validation.IsValid)
        {
            return await _validationService.GetErrors(validation);
        }
        PlayResponse playResponse = await _playPhaseService.Play(playRequest);
        Response<PlayResponse> response = new();
        if (playResponse is null)
        {
            return response.Fail(ApiSharedConst.SomethingWentWrong); // Error come from DataBase 
        }
        return response.Success
        (
            content: playResponse,
            message: ApiSharedConst.EverthingOk
        );
    }
}
