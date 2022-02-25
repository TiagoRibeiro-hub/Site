using FluentValidation;
using Games.Data.Game;
using Games.Infrastructure;

namespace Games.Core.Validators;

public class PlayRequestValidator : AbstractValidator<PlayRequest>
{
    public PlayRequestValidator(MovementValidation movementValidation)
    {
        // PossibleMoves
        RuleFor(x => x.PossibleMoves)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().NotNull()
            .DependentRules(() =>
            {
                // GameType & GameTypeOptions
                RuleFor(x => x.GetGameType)
                    .SetValidator(x => new GameOptionsValidator(x.GetGameType.GameTypeName))
                    .DependentRules(() =>
                    {
                        // Id Game & Players
                        // if TicTacToe
                        When(x => GameType.TicTacToe.GetGameType(x.GetGameType.GameTypeName), () =>
                        {
                            PlayRules(movementValidation);
                        });
                        // if Chess
                        When(x => GameType.Chess.GetGameType(x.GetGameType.GameTypeName), () =>
                        {
                            PlayRules(movementValidation);
                        });
                    });
            });
    }

    private void PlayRules(MovementValidation movementValidation)
    {
        // Id Game
        RuleFor(x => x.IdGame)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().NotNull()
            .GreaterThan(0)
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
                                .SetValidator(new MovementValidator(movementValidation));
                        })
                        // computer playing
                        .Otherwise(() =>
                        {
                            RuleFor(x => x.VsComputer.Difficulty)
                                .IsDifficultyExistWithMessage();

                            RuleFor(x => x.PlayerName)
                                .NotNull().NotEmpty()
                                .Equal(Computer.Name);
                        });
                    });
            });
    }
}
