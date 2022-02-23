using FluentValidation;

namespace Games.Core.Validators;

public static class CommonPropertyValidation
{
    public static IRuleBuilderOptions<T, string> PlayerNameRule<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().NotNull()
            .MinimumLength(3).MaximumLength(20)
            .Matches("^[a-zA-Z0-9 ]*$")
            .WithMessage("Player name just allow letters, numbers and space");
    }
}
