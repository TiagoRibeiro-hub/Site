using FluentValidation;

namespace Games.Core.Validators;
public class RegisterPlayerRequestValidator : AbstractValidator<RegisterPlayerRequest>
{
    public RegisterPlayerRequestValidator()
    {
        RuleFor(x => x.Player).SetValidator(new PlayerValidator());
    }
}
