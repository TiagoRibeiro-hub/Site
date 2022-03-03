using _00.Data.Api.InitializeGame;
using _00.Data.Api.PlayerRegister;
using ApiShared;
using FluentValidation.Results;

namespace _02.Games.Core.Validations;
public interface IValidationService
{
    Task<Response<Error>> GetErrors(ValidationResult validationResult);
    Task<ValidationResult> ValidateRegisterPlayerRequest(RegisterPlayerRequest registerPlayer);
    Task<ValidationResult> ValidateInitializeGameRequest(InitializeGameRequest initializeGame);
}
