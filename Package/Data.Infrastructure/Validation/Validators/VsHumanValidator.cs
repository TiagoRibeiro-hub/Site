using Data.Infrastructure.Data.Game.Player;
using FluentValidation;

namespace Data.Infrastructure.Validation.Validators;

public class VsHumanValidator : AbstractValidator<VsHuman>
{
    public VsHumanValidator()
    {
        RuleFor(x => x.PlayerName_2)
            .Cascade(CascadeMode.Stop)
            .PlayerNameRule();
    }
}
