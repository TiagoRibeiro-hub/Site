using _00.Data.Api.InitializeGame;
using _00.Data.Api.PlayerRegister;
using _00.Data.Api.PlayGame;
using _02.Games.Core.Services._03_InitializePhase;
using _02.Games.Core.Services.RegisterPlayerPhase;
using _02.Games.Core.Validations;
using ApiShared;

namespace _02.Games.Core.Services.GamePhases;
#nullable disable
public class GamePhases : IGamePhasesService
{
    private readonly IValidationService _validationService;
    private readonly IRegisterPlayerPhaseService _registerPlayerPhaseService;
    private readonly IInitializePhaseService _initializePhaseService;
    public GamePhases(
        IValidationService validationService,
        IRegisterPlayerPhaseService registerPlayerPhaseService, 
        IInitializePhaseService initializePhaseService)
    {
        _validationService = validationService;
        _registerPlayerPhaseService = registerPlayerPhaseService;
        _initializePhaseService = initializePhaseService;
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
        var validation = await _validationService.ValidateInitializeGameRequest(initializeGame);
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

    public Task<Response> Play(PlayRequest playRequest)
    {
        throw new NotImplementedException();
    }


}
