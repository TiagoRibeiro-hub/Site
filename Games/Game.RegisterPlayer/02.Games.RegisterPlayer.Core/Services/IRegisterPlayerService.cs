using _01.Games.RegisterPlayer.Infrastructure;
using _02.Games.RegisterPlayer.Core.Repoitory;
using ApiShared;
using Data.Infrastructure.Infrastructure.Api.PlayerRegister;
using Data.Infrastructure.Validation;

namespace _02.Games.RegisterPlayer.Core.Services;
public interface IRegisterPlayerService
{
    Task<Response> SetRegisterPlayerResponse(RegisterPlayerRecord registerPlayer);
}

public class RegisterPlayerImplementation : IRegisterPlayerService
{
    private readonly IRegisterPlayerValidationService _validationService;
    private readonly IValidationErrorService _validationErrorService;
    private readonly IRegisteredPlayersRepository _registeredPlayersRepository;
    public RegisterPlayerImplementation(
        IRegisterPlayerValidationService validationService,
        IValidationErrorService validationErrorService, 
        IRegisteredPlayersRepository registeredPlayersRepository)
    {
        _validationService = validationService;
        _validationErrorService = validationErrorService;
        _registeredPlayersRepository = registeredPlayersRepository;
    }

    public async Task<Response> SetRegisterPlayerResponse(RegisterPlayerRecord registerPlayer)
    {
        var validation = await _validationService.ValidateRegisterPlayerRequest(registerPlayer);
        if (!validation.IsValid)
        {
            return await _validationErrorService.GetErrors(validation);
        }
        Response<RegisterPlayerResponse> response = new();
        await _registeredPlayersRepository.RegisteredPlayersWrite.InsertAsync(registerPlayer.SetRegisteredPlayersEntity());
        //await InitializeScoreTable(registerPlayer.Player.Name);
        // message broker
        await _registeredPlayersRepository.Complete();
        return response.Success
                    (
                        content: new RegisterPlayerResponse(playerName: true, email: true),
                        message: "Successful registration"
                    );
    }
}
