using FluentValidation;
using Games.Infrastructure;

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
                    PlayRules(GameType.TicTacToe);
                });

                // if Chess
                When(x => x.GameType.GameTypeName.ToUpper() == GameType.Chess.GameTypeToStringUpper(), () =>
                {
                    PlayRules(GameType.Chess);
                });
            });
    }

    private void PlayRules(GameType gameType)
    {
        // Id Game
        RuleFor(x => x.IdGame)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().NotNull()
            .GreaterThan(0)
            .DependentRules(() =>
            {
                // PossibleMoves
                RuleFor(x => x.PossibleMoves)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().NotNull()
                    .DependentRules(() =>
                    {
                        // vsComputer
                        RuleFor(x => x.VsComputer.IsComputer)
                            .Cascade(CascadeMode.Stop)
                            .NotEmpty().NotNull()
                            .Must(x => x == false || x == true)
                            .DependentRules(() =>
                            {
                                // human playing
                                Unless(x => x.VsComputer.IsComputer == false, () =>
                                {
                                    // Movement
                                    RuleFor(x => x.Movements)
                                        .SetValidator(new MovementValidator(gameType.GameTypeToStringUpper()));

                                }).Otherwise(() =>
                                {
                                    RuleFor(x => x.VsComputer.Difficulty).IsDifficultyExistWithMessage();
                                });
                            });
                    });
            });
    }
}
