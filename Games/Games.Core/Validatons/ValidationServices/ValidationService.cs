using FluentValidation.Results;
using Games.Core.Validators;

namespace Games.Core.Validatons;

public class ValidationService : IValidationService
{
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

    public Task<ValidationResult> ValidateRegisterPlayerRequest(RegisterPlayerRequest registerPlayer)
    {
        RegisterPlayerRequestValidator validationRules = new();
        var validation = validationRules.Validate(registerPlayer);
        return Task.FromResult(validation);
    }

    public Task<ValidationResult> InitializeGameRequestValidator(InitializeGameRequest initializeGame)
    {
        InitializeGameRequestValidator validationRules = new();
        var validation = validationRules.Validate(initializeGame);
        return Task.FromResult(validation);
    }
}
