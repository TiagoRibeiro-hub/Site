using Data.Infrastructure.Data.Game.Player;
using Data.Infrastructure.Infrastructure.Api.InitializeGame;
using FluentValidation;
using FluentValidation.Results;

namespace Data.Infrastructure.Validation.Validators;

public class InitializeGameValidator : AbstractValidator<InitializeGameRequest>
{
    public InitializeGameValidator()
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
                        RuleFor(x => x.VsComputer)
                        .Cascade(CascadeMode.Stop)
                        .SetValidator(new VsComputerValidator())
                        .DependentRules(() =>
                        {
                            When(x => x.VsComputer.IsComputer == true, () =>
                            {
                                StartFirstRules();
                            })
                            .Otherwise(() =>
                            {
                                RuleFor(x => x.VsHuman)
                                   .Cascade(CascadeMode.Stop)
                                   .SetValidator(new VsHumanValidator())
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
                RuleFor(x => x.StartFirst)
                .Custom((startFirst, context) =>
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
                RuleFor(x => x.StartFirst)
                .Custom((startFirst, context) =>
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