using FluentValidation;

namespace Games.Core.Validators;

public static class DifficultyRulesExtensions
{
    public static IRuleBuilderOptions<T, string> IsDifficultyExistWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must((difficulty) =>
        {
            foreach (var item in EnumsList.GetDifficultyList())
            {
                if (difficulty.ToUpper() == item)
                {
                    return true;
                }
            }
            return false;
        }).WithMessage("Difficulties are: Easy; Intermediate; Hard");
    }
}