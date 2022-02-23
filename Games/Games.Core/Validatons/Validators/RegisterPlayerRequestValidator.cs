using FluentValidation;

namespace Games.Core.Validators;
public class RegisterPlayerRequestValidator : AbstractValidator<RegisterPlayerRequest>
{
    public RegisterPlayerRequestValidator()
    {
        RuleFor(x => x.Player.Name)
            .NotEmpty().NotNull()
            .MinimumLength(3).MaximumLength(20)
            .Matches("^[a-zA-Z0-9 ]*$");

        RuleFor(x => x.Player.Email)
            .NotEmpty().NotNull()
            .EmailAddress();
    }
}
