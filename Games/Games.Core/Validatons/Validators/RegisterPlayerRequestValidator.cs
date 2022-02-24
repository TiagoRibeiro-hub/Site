using FluentValidation;
using Games.Infrastructure;

namespace Games.Core.Validators;
public class RegisterPlayerRequestValidator : AbstractValidator<RegisterPlayerRequest>
{
    public RegisterPlayerRequestValidator(IRegisteredPlayersRepository registeredPlayersRepository)
    {
        RuleFor(x => x.Player).SetValidator(new PlayerValidator(registeredPlayersRepository));
    }
}
