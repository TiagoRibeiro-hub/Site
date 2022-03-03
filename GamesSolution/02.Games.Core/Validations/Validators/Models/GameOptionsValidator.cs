using _00.Data.Enums;
using _00.Data.Extensions;
using _00.Data.Game;
using FluentValidation;
using System.Text;

namespace _02.Games.Core.Validations;

public class GameOptionsValidator : AbstractValidator<GameOptions>
{
    public GameOptionsValidator(string gameType)
    {
        RuleFor(x => x.GameTypeName)
            .Cascade(CascadeMode.Stop)
            .NotNull().NotEmpty()
            .IsGameTypeExistWithMessage()
            .DependentRules(() =>
            {
                RuleFor(x => x.GetGameTypeOptions).SetValidator(new GameTypeOptionsValidator(gameType));
            });
    }
}

public class GameTypeOptionsValidator : AbstractValidator<GameTypeOptions>
{
    public GameTypeOptionsValidator(string gameType)
    {
        if (GameType.TicTacToe.GetGameType(gameType))
        {
            RuleFor(x => x.TicTacToeNumberColumns)
                .Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty()
                .IsOddNumberWithMessage();
        }

    }
}

public static class GameTypeRulesExtensions
{
    public static IRuleBuilderOptions<T, string> IsGameTypeExistWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        HashSet<string> gameTypesList = EnumsExtensions.GetGameTypeList();
        StringBuilder sb = new StringBuilder();
        sb.Append("The game types are:");
        foreach (var item in gameTypesList)
        {
            sb.Append(" " + item.ToUpper() + ";");
        }
        return ruleBuilder.Must((gameType) =>
        {
            foreach (var item in gameTypesList)
            {
                if (gameType.ToUpper() == item)
                {
                    return true;
                }
            }
            return false;
        }).WithMessage(sb.ToString().Remove(sb.Length - 1, 1));
    }

    public static IRuleBuilderOptions<T, int> IsOddNumberWithMessage<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.Must((ticTacToeNumberColumns) =>
        {
            if (ticTacToeNumberColumns % 2 == 0 || ticTacToeNumberColumns < 3)
            {
                return false;
            }
            return true;
        }).WithMessage("TicTacToe Number of Columns must start at 3 and be a odd number");
    }
}
