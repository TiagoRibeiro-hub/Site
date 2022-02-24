using FluentValidation;
using Games.Data.Game;

namespace Games.Core.Validators;

public class InitializeGameRequestValidator : AbstractValidator<InitializeGameRequest>
{
    public InitializeGameRequestValidator()
    {
        RuleFor(x => x.GameType)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().NotNull()
            .Must(IsGameTypeExist);

        When(IsGameTypeTicTacToe, () =>
        {
            RuleFor(x => x.GameOptions.TicTacToeNumberColumns)
                .NotEmpty().NotNull()
                .Must(IsOddNumber)
                .WithMessage("TicTacToe Number of Columns must start at 3 and be a odd number");
        });

        RuleFor(x => x.PlayerName_1).PlayerNameRule();

        // if true
        When(IsVsComputer, () =>
        {
            RuleFor(x => x.VsComputer.Difficulty)
            .NotEmpty().NotNull()
            .Must(IsDificultyExist);

        }).Otherwise(() =>
        {
            RuleFor(x => x.VsHuman).SetValidator(new VsHumanValidator());
        });

        // Start First
        #region StartFirst
        RuleFor(x => x.StartFirst).NotEmpty().NotNull();
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
        #endregion
    }


    // Start First Methods
    #region StartFirst
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
    // ENUMS
    protected static bool IsDificultyExist(string arg)
    {
        return false;
    }
    protected static bool IsGameTypeTicTacToe(InitializeGameRequest arg)
    {
        if (!string.IsNullOrWhiteSpace(arg.GameType))
        {
            if (GameType.TicTacToe.GetGameType(arg.GameType))
            {
                return true;
            }
        }
        return false;
    }
    private bool IsOddNumber(int ticTacToeNumberColumns)
    {
        if (ticTacToeNumberColumns % 2 == 0 || ticTacToeNumberColumns < 3)
        {
            return false;
        }
        return true;
    }

    protected static bool IsGameTypeExist(string gameType)
    {
        foreach (var item in GameTypeEnum.GetList())
        {
            if (gameType.ToUpper() == item)
            {
                return true;
            }
        }
        return false;
    }

}