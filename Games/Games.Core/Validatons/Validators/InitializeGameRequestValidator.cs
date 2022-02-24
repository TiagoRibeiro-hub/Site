using FluentValidation;
using Games.Data.Game;
using Games.Infrastructure;


namespace Games.Core.Validators;
public class InitializeGameRequestValidator : AbstractValidator<InitializeGameRequest>
{
    public InitializeGameRequestValidator(ITicTacToeReadRepository ticTacToeReadRepository)
    {
        RuleFor(x => x.GameType)
            .SetValidator(x => new GameOptionsValidator(x.GameType.GameTypeName))
            .DependentRules(() =>
            {
                // GameTypeOptions And Players
                // if TicTacToe
                When(x => x.GameType.GameTypeName.ToUpper() == GameType.TicTacToe.GameTypeToStringUpper(), () =>
                {
                    RulesForPlayers(ticTacToeReadRepository, GameType.TicTacToe);
                });

                // if Chess
                When(x => x.GameType.GameTypeName.ToUpper() == GameType.Chess.GameTypeToStringUpper(), () =>
                {
                    RulesForPlayers(ticTacToeReadRepository, GameType.Chess);
                });
            });

    }

    // Players Rules
    private void RulesForPlayers(ITicTacToeReadRepository ticTacToeReadRepository, GameType gameType)
    {
        RuleFor(x => x.PlayerName_1)
            .Cascade(CascadeMode.Stop)
            .PlayerNameRule()
            .IsPlayerAllowedToPlayWithMessage(ticTacToeReadRepository, gameType)
            .DependentRules(() =>
            {
                // if vsComputer
                When(IsVsComputer, () =>
                {
                    RuleFor(x => x.VsComputer.Difficulty)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().NotNull()
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
                        .IsPlayerAllowedToPlayWithMessage(ticTacToeReadRepository, gameType)
                        .DependentRules(() =>
                        {
                            StartFirstRules();
                        }); 
                });
            });
    }
    // Start First Rules
    private void StartFirstRules()
    {
        RuleFor(x => x.StartFirst)
            .NotEmpty().NotNull();

        // if vs computer
        When(IsVsComputer, () =>
        {
            // if false
            Unless(ConfirmPlayersVsComputer, () =>
            {
                RuleFor(x => x.StartFirst)
                    .Equal(Computer.Name).OverridePropertyName("StartFirst Option1")
                    .WithMessage($"If computer start first write '{Computer.Name}'.");

                RuleFor(x => x.StartFirst)
                    .Equal(x => x.PlayerName_1).OverridePropertyName("StartFirst Option2")
                    .WithMessage("If player1 start first write Player1 name.");
            });

        }).Otherwise(() =>
        {
            // if false
            Unless(ConfirmPlayers, () =>
            {
                RuleFor(x => x.StartFirst)
                    .Equal(x => x.PlayerName_1).OverridePropertyName("StartFirst Option1")
                    .WithMessage("If player1 start first write Player1 name.");

                RuleFor(x => x.StartFirst)
                    .Equal(x => x.VsHuman.PlayerName_2).OverridePropertyName("StartFirst Option2")
                    .WithMessage("If player2 start first write Player2 name.");
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
