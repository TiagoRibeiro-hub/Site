using _00.Data.Api.InitializeGame;
using _00.Data.Enums;
using _00.Data.Extensions;
using _00.Data.Game.Player;
using FluentValidation;
using FluentValidation.Results;

namespace _02.Games.Core.Validations;

public class InitializeGameRequestValidator : AbstractValidator<InitializeGameRequest>
{
    public InitializeGameRequestValidator()
    {
        RuleFor(x => x.GetGameOptions)
            .Cascade(CascadeMode.Stop)
            .SetValidator(x => new GameOptionsValidator(x.GetGameOptions.GameTypeName))
            .DependentRules(() =>
            {
                RuleFor(x => x.PlayerName_1)
                    .Cascade(CascadeMode.Stop)
                    .PlayerNameRule()
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.VsComputer.IsComputer)
                        .Cascade(CascadeMode.Stop)
                        .NotNull()
                        .Must(x => x == false || x == true)
                        .DependentRules(() =>
                        {
                            // if vsComputer
                            When(IsVsComputer, () =>
                            {
                                RuleFor(x => x.VsComputer.Difficulty)
                                .Cascade(CascadeMode.Stop)
                                .NotNull().NotEmpty()
                                .IsDifficultyExistWithMessage()
                                .DependentRules(() =>
                                {
                                    StartFirstRules();
                                });

                            }).Otherwise(() =>
                            {
                                RuleFor(x => x.VsHuman.PlayerName_2)
                                    .Cascade(CascadeMode.Stop)
                                    .PlayerNameRule()
                                    .DependentRules(() =>
                                    {
                                        StartFirstRules();
                                    });
                            });
                        });
                    });
            });
    }

    // Start First Rules
    private void StartFirstRules()
    {
        RuleFor(x => x.StartFirst)
            .NotNull().NotEmpty();

        // if vs computer
        When(IsVsComputer, () =>
        {
            // if false
            Unless(ConfirmPlayersVsComputer, () =>
            {
                RuleFor(x => x.StartFirst).Custom((startFirst, context) =>
                {
                    context.AddFailure(new ValidationFailure("Start First Option1", $"If computer start first write '{Computer.Name}'"));
                    context.AddFailure(new ValidationFailure("Start First Option2", "If player1 start first write Player1 name."));
                });
            });

        }).Otherwise(() =>
        {
            // if false
            Unless(ConfirmPlayers, () =>
            {
                RuleFor(x => x.StartFirst).Custom((startFirst, context) =>
                {
                    context.AddFailure(new ValidationFailure("Start First Option1", "If player1 start first write Player1 name."));
                    context.AddFailure(new ValidationFailure("Start First Option2", "If player2 start first write Player2 name."));
                });
            });
        });
    }

    // Start First Methods
    #region StartFirstMethods
    protected static bool ConfirmPlayersVsComputer(InitializeGameRequest arg)
    {
        if (arg.StartFirst == arg.PlayerName_1 || arg.StartFirst == Computer.Name)
        {
            return true;
        }
        return false;
    }
    protected static bool ConfirmPlayers(InitializeGameRequest arg)
    {
        if (arg.StartFirst == arg.PlayerName_1 || arg.StartFirst == arg.VsHuman.PlayerName_2)
        {
            return true;
        }
        return false;
    }
    protected static bool IsVsComputer(InitializeGameRequest arg)
    {
        if (arg.VsComputer.IsComputer)
        {
            return true;
        }
        return false;
    }
    #endregion
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