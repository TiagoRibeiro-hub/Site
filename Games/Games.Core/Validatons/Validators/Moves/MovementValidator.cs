using FluentValidation;
using Games.Data.Game;

namespace Games.Core.Validators;

public class MovementValidator : AbstractValidator<Movement>
{
    public MovementValidator(MovementValidation movementValidation)
    {
        RuleFor(x => x.MoveNumber)
            .Cascade(CascadeMode.Stop)
            .NotNull().NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(movementValidation.GetPossibleMoves.Count)
            .DependentRules(() =>
            {
                RuleFor(x => x.MoveTo)
                    .Cascade(CascadeMode.Stop)
                    .MoveRules()
                    .DependentRules(() =>
                    {
                        if (GameType.TicTacToe.GetGameType(movementValidation.GetGameType.GameTypeName))
                        {
                            RuleFor(x => x.MoveTo)
                                .Cascade(CascadeMode.Stop)
                                .MoveMinimum1Rules()
                                .DependentRules(() =>
                                {
                                    When(x => PossibleMovesContainsMoveTo(x.MoveTo, movementValidation), () =>
                                    {
                                        Unless(x => IsMoveToAccepted(x.MoveTo, movementValidation), () =>
                                        {
                                            RuleFor(x => x.MoveTo)
                                                .Custom((moveTo, context) =>
                                                {
                                                    context.AddFailure($"Possible moves between 1 & {movementValidation.GetPossibleMoves.Count}");
                                                });
                                        });
                                    })
                                    .Otherwise(() =>
                                    {
                                        RuleFor(x => x.MoveTo)
                                            .Custom((moveTo, context) =>
                                            {
                                                context.AddFailure($"{moveTo} has already been played");
                                            });
                                    });
                                })
                                .DependentRules(() =>
                                {
                                    RuleFor(x => x.MoveFrom)
                                        .Custom((moveFrom, context) =>
                                        {
                                            if (string.IsNullOrEmpty(moveFrom) == false)
                                            {
                                                context.AddFailure($"MoveFrom must be Null or Empty");
                                            }
                                        });
                                });
                        }
                        if (GameType.Chess.GetGameType(movementValidation.GetGameType.GameTypeName))
                        {
                            RuleFor(x => x.MoveFrom)
                                .Cascade(CascadeMode.Stop)
                                .MoveMinimum2Rules()// confirmation
                                .DependentRules(() =>
                                {
                                    RuleFor(x => x.MoveTo)
                                        .Cascade(CascadeMode.Stop)
                                        .MoveMinimum2Rules();// confirmation
                                });  
                        }
                    });
            });
    }

    // Methods
    #region Methods
    protected static bool PossibleMovesContainsMoveTo(string moveTo, MovementValidation movementValidation)
    {
        if (movementValidation.GetPossibleMoves.ContainsValue(moveTo) == false)
        {
            return false;
        }
        return true;
    }
    protected static bool IsMoveToAccepted(string moveTo, MovementValidation movementValidation)
    {
        if (GameType.TicTacToe.GetGameType(movementValidation.GetGameType.GameTypeName))
        {
            int nrcolumns = movementValidation.GetGameType.GetGameTypeOptions.TicTacToeNumberColumns * movementValidation.GetGameType.GetGameTypeOptions.TicTacToeNumberColumns;
            if (int.Parse(moveTo) < 1 || int.Parse(moveTo) > nrcolumns)
            {
                return false;
            }
        }
        return true;
    }
    #endregion
}