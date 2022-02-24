using FluentValidation;

namespace Games.Core.Validators;

public class VsHumanValidator : AbstractValidator<VsHuman>
{
    public VsHumanValidator()
    {
        RuleFor(x => x.PlayerName_2).PlayerNameRule();
    }
}
