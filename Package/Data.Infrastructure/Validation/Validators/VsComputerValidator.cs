using Data.Infrastructure.Data.Extensions;
using Data.Infrastructure.Data.Game.Player;
using FluentValidation;

namespace Data.Infrastructure.Validation.Validators;

public class VsComputerValidator : AbstractValidator<VsComputer>
{
    public VsComputerValidator()
    {
        RuleFor(x => x.IsComputer)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .Must(x => x == false || x == true)
            .WithMessage("IsComputer must be true or false")
            .DependentRules(() =>
            {
                // if vsComputer
                When(x => x.IsComputer == true, () =>
                {
                    RuleFor(x => x.Difficulty)
                        .Cascade(CascadeMode.Stop)
                        .NotNull().NotEmpty()
                        .IsDifficultyExistWithMessage();
                });
            });
    }
}

public static class DifficultyRulesExtensions
{
    public static IRuleBuilderOptions<T, string> IsDifficultyExistWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must((difficulty) =>
        {
            foreach (var item in EnumsExtensions.GetDifficultyList())
            {
                if (difficulty.ToUpper() == item)
                {
                    return true;
                }
            }
            return false;
        }).WithMessage("Difficulties are: Easy; Intermediate and Hard");
    }
}
