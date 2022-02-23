using FluentValidation;

namespace Games.Core.Validators;

public class InitializeGameRequestValidator : AbstractValidator<InitializeGameRequest>
{
    public InitializeGameRequestValidator()
    {
        RuleFor(x => x.GameType)
            .NotEmpty().NotNull()
            .Must(IsGameTypeExist)
            .WithSeverity(Severity.Warning);

        When(IsGameTypeTicTacToe, () =>
        {
            RuleFor(x => x.GameOptions.TicTacToeNumberColumns).NotEmpty().NotNull().WithSeverity(Severity.Warning);
        });

        RuleFor(x => x.VsHuman).SetValidator(new VsHumanValidator());
    }

    private bool IsGameTypeTicTacToe(InitializeGameRequest arg)
    {
        if(GameType.TicTacToe.GetGameType(arg.GameType))
        {
            return true;
        }
        return false;
    }

    protected bool IsGameTypeExist(string gameType)
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