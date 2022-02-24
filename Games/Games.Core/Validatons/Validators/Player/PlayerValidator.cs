using FluentValidation;
using Games.Data.Game;

using Games.Infrastructure;

namespace Games.Core.Validators;

public class PlayerValidator : AbstractValidator<Player>
{
    public PlayerValidator(IRegisteredPlayersRepository registeredPlayersRepository)
    {

        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .PlayerNameRule()
            .MustAsync(async (playerName, cancellation) =>
             {
                 var isExist = await registeredPlayersRepository.IsExistByPlayerName(playerName);
                 if (isExist)
                 {
                     return false;
                 }
                 return true;
             })
            .WithMessage("This player name is already exist.");

        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().NotNull()
            .EmailAddress()
            .MustAsync(async (email, cancellation) =>
            {
                var isExist = await registeredPlayersRepository.IsExistByEmail(email);
                if (isExist)
                {
                    return false;
                }
                return true;
            })
            .WithMessage("This Email is already exist.");
    }
}
