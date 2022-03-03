using _00.Data.Api.InitializeGame;
using _00.Data.Api.PlayerRegister;
using _02.Games.Core.Repository;
using ApiShared;
using FluentValidation.Results;

namespace _02.Games.Core.Validations;

public class ValidationService : IValidationService
{
    private readonly IRegisteredPlayersRepository _registeredPlayersRepository;

    public ValidationService(IRegisteredPlayersRepository registeredPlayersRepository)
    {
        _registeredPlayersRepository = registeredPlayersRepository;
    }

    public Task<Response<Error>> GetErrors(ValidationResult validationResult)
    {
        var errors = validationResult.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage).ToArray();
        Error errorResponse = new();
        foreach (var item in errors)
        {
            ErrorModel errorModel = new()
            {
                FieldName = item.Key.ToString(),
                Message = item.Value.ToString(),
            };
            errorResponse.Errors.Add(errorModel);
        }
        Response response = new();
        return Task.FromResult(response.Fail(content: errorResponse));
    }
    public async Task<ValidationResult> ValidateRegisterPlayerRequest(RegisterPlayerRequest registerPlayer)
    {
        RegisterPlayerRequestValidator validationRules = new(_registeredPlayersRepository);
        var validation = await validationRules.ValidateAsync(registerPlayer);
        return validation;
    }

    public async Task<ValidationResult> ValidateInitializeGameRequest(InitializeGameRequest initializeGame)
    {
        InitializeGameRequestValidator validationRules = new();
        var validation = await validationRules.ValidateAsync(initializeGame);
        // falta conferir o player com o jogo
        return validation;
    }
}