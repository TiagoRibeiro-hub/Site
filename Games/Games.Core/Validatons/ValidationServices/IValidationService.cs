using FluentValidation.Results;

namespace Games.Core.Validatons;

public interface IValidationService
{
    Task<Response<Error>> GetErrors(ValidationResult validationResult);
    Task<ValidationResult> ValidateRegisterPlayerRequest(RegisterPlayerRequest registerPlayer);
    Task<ValidationResult> InitializeGameRequestValidator(InitializeGameRequest initializeGame);
    Task<ValidationResult> PlayRequestValidator(PlayRequest playRequest);
}