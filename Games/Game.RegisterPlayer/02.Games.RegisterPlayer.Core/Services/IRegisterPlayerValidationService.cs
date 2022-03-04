using _01.Games.RegisterPlayer.Infrastructure;
using _02.Games.RegisterPlayer.Core.Repoitory;
using _02.Games.RegisterPlayer.Core.Validators;
using Data.Infrastructure.Infrastructure.Api.PlayerRegister;
using FluentValidation.Results;

namespace _02.Games.RegisterPlayer.Core.Services;

public interface IRegisterPlayerValidationService
{
    Task<ValidationResult> ValidateRegisterPlayerRequest(RegisterPlayerRecord registerPlayer);
}

public class RegisterPlayerValidation : IRegisterPlayerValidationService
{
    public readonly IRegisteredPlayersRepository _registeredPlayersRepository;

    public RegisterPlayerValidation(IRegisteredPlayersRepository registeredPlayersRepository)
    {
        _registeredPlayersRepository = registeredPlayersRepository;
    }

    public async Task<ValidationResult> ValidateRegisterPlayerRequest(RegisterPlayerRecord registerPlayer)
    {
        try
        {
            RegisterPlayerRequestValidator validationRules = new(_registeredPlayersRepository);
            var validation = await validationRules.ValidateAsync(registerPlayer);
            if(validation is null)
            {
                throw new Exception("Validation is null");
            }
            return validation;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
}
