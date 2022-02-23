using FluentValidation;
using Games.Data.Game;

using System.Collections.Generic;
using FluentValidation.Validators;

namespace Games.Core.Validators;

public class PlayerValidator : AbstractValidator<Player>
{
    public PlayerValidator()
    {
        RuleFor(x => x.Name).PlayerNameRule();
        RuleFor(x => x.Email)
            .NotEmpty().NotNull()
            .EmailAddress();
    }
}

public class VsHumanValidator : AbstractValidator<VsHuman>
{
    public VsHumanValidator()
    {
        RuleFor(x => x.PlayerName_2).PlayerNameRule();
    }
}
