using FluentValidation;


namespace Games.Core.Validators;

public class PlayRequestValidator : AbstractValidator<PlayRequest>
{
    public PlayRequestValidator()
    {
        RuleFor(x => x.GameType)
            .SetValidator(x => new GameOptionsValidator(x.GameType.GameTypeName))
            .DependentRules(() =>
            {
                // GameTypeOptions And Players
                // if TicTacToe
                When(x => x.GameType.GameTypeName.ToUpper() == GameType.TicTacToe.GameTypeToStringUpper(), () =>
                {
                    RuleFor(x => x.IdGame)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty().NotNull()
                        .GreaterThan(0)
                        .DependentRules(() =>
                        {

                        });
                });

                // if Chess
                When(x => x.GameType.GameTypeName.ToUpper() == GameType.Chess.GameTypeToStringUpper(), () =>
                {
                    
                });
            });
    }
}