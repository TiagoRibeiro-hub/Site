using FluentValidation;
using Games.Data.Game;

namespace Games.Core.Validators;

public class MovementValidator : AbstractValidator<Movement>
{
    public MovementValidator(string gameType)
    {

    }
}