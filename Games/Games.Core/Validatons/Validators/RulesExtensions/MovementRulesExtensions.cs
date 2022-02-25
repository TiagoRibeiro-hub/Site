using FluentValidation;
using Games.Data.Game;

namespace Games.Core.Validators;

public static class MovementRulesExtensions
{
    public static IRuleBuilderOptions<T, string> MoveRules<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().NotNull();
    }
    public static IRuleBuilderOptions<T, string> MoveMinimum1Rules<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinimumLength(1).MaximumLength(2);
    }
    public static IRuleBuilderOptions<T, string> MoveMinimum2Rules<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.MinimumLength(2).MaximumLength(2);
    }
}



