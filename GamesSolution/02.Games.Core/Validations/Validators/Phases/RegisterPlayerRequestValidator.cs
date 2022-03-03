using _00.Data.Api.PlayerRegister;
using _02.Games.Core.Repository;
using FluentValidation;

namespace _02.Games.Core.Validations;
public class RegisterPlayerRequestValidator : AbstractValidator<RegisterPlayerRequest>
{
    public RegisterPlayerRequestValidator(IRegisteredPlayersRepository _registeredPlayersRepository)
    {
        RuleFor(x => x.Player).SetValidator(new PlayerValidator(_registeredPlayersRepository));
    }
}
