using Data.Infrastructure.Data.Game.Player;
using FluentValidation;

namespace Data.Infrastructure.Validation.Validators;

public class PlayerValidator : AbstractValidator<Player>
{
    public PlayerValidator()
    {
        RuleFor(x => x.Name)
           .Cascade(CascadeMode.Stop)
           .PlayerNameRule();

        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotNull().NotEmpty()
            .EmailAddress();
    }
}

public static class PlayerNameRulesExtensions
{
    public static IRuleBuilderOptions<T, string> PlayerNameRule<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotNull().NotEmpty()
            .MinimumLength(3).MaximumLength(20)
            .Matches("^[a-zA-Z0-9 ]*$")
            .WithMessage("Player name just allow letters, numbers and space");
    }
}

