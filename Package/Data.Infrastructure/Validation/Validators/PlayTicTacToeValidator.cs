using Data.Infrastructure.Infrastructure.Api.PlayGame;
using FluentValidation;

namespace Data.Infrastructure.Validation.Validators;

public class PlayTicTacToeValidator : AbstractValidator<PlayTicTacToeRequest>
{
    public PlayTicTacToeValidator()
    {
        RuleFor(x => x.TicTacToeNumberColumns)
            .Cascade(CascadeMode.Stop)
            .IsOddNumberWithMessage()
            .DependentRules(() =>
            {
                RuleFor(x => x.PossibleMoves)
                    .PossibleMovesRules()
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.VsComputer)
                            .Cascade(CascadeMode.Stop)
                            .SetValidator(new VsComputerValidator())
                            .DependentRules(() =>
                            {
                                Unless(x => x.VsComputer.IsComputer == false, () =>
                                {
                                    RuleFor(x => x.PlayerName)
                                        .PlayerNameRule();

                                    RuleFor(x => x.Movements)
                                        .SetValidator(x => new MovementsValidator(x.PossibleMoves.Count))
                                        .DependentRules(() =>
                                        {
                                            RuleFor(x => x.Movements.MoveFrom)
                                                .NullMoveRuleWithMessage()
                                                .DependentRules(() =>
                                                {
                                                    RuleFor(x => x.Movements.MoveTo)
                                                        .NotNullNotEmptyMoveRuleWithMessage();
                                                });
                                        });
                                })
                                .Otherwise(() =>
                                {
                                    RuleFor(x => x.Movements.MoveFrom)
                                        .NullMoveRuleWithMessage();

                                    RuleFor(x => x.Movements.MoveTo)
                                        .NullMoveRuleWithMessage();
                                });
                            });

                    }).WithMessage("PossibleMoves does not exist.");
            });
    }
}
