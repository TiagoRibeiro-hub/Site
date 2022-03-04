using Data.Infrastructure.Data.Game.Moves;
using FluentValidation;

namespace Data.Infrastructure.Validation.Validators;

public class MovementsValidator : AbstractValidator<Movement>
{
    public MovementsValidator(int possibleMovesCount)
    {
        RuleFor(x => x.MoveNumber)
            .NotNull().NotEmpty()
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(possibleMovesCount);

        RuleFor(x => x.MoveFrom)
            .MoveRulesExistWithMessage();

        RuleFor(x => x.MoveTo)
            .MoveRulesExistWithMessage();
    }
}

public static class MovementsRulesExtensions
{
    public static IRuleBuilderOptions<T, string> MoveRulesExistWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Length(1, 2)
                            .WithMessage("Minimum lenght 1 and maximun 2");
    }
    public static IRuleBuilderOptions<T, Dictionary<string, string>> PossibleMovesRules<T>(this IRuleBuilder<T, Dictionary<string, string>> ruleBuilder)
    {
        return ruleBuilder.NotNull().NotEmpty();
    }
    public static IRuleBuilderOptions<T, string> NullMoveRuleWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotNull().WithMessage("MoveFrom must be null");
    }
    public static IRuleBuilderOptions<T, string> NotNullNotEmptyMoveRuleWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotNull().NotEmpty();
    }
}
