using FluentValidation;


namespace Games.Core.Validators;

public class GameOptionsValidator : AbstractValidator<GameOptions>
{
    public GameOptionsValidator(string gameType)
    {
        RuleFor(x => x.GameTypeName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().NotNull()
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
                .NotEmpty().NotNull()
                .IsOddNumberWithMessage();
        }
        
    }
}