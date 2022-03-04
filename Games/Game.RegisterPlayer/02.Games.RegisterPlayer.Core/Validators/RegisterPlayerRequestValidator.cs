using _01.Games.RegisterPlayer.Infrastructure;
using _02.Games.RegisterPlayer.Core.Repoitory;
using Data.Infrastructure.Data._Entities;
using Data.Infrastructure.Validation.Validators;
using FluentValidation;
using System.Linq.Expressions;

namespace _02.Games.RegisterPlayer.Core.Validators;
public class RegisterPlayerRequestValidator : AbstractValidator<RegisterPlayerRecord>
{
    public RegisterPlayerRequestValidator(IRegisteredPlayersRepository _registeredPlayersRepository)
    {
        RuleFor(x => x.Player)
            .SetValidator(new PlayerValidator())
            .DependentRules(() =>
            {
                RuleFor(x => x.Player.Name)
                    .MustAsync(async (playerName, cancellation) =>
                    {
                        Expression<Func<RegisteredPlayersEntity, bool>> predicate = x => x.PlayerName == playerName;
                        var isExist = await _registeredPlayersRepository.RegisteredPlayersRead.IsAnyAsync(predicate);
                        if (isExist)
                        {
                            return false;
                        }
                        return true;
                    }).WithMessage("This player name is already exist.");

                RuleFor(x => x.Player.Email)
                    .MustAsync(async (playerEmail, cancellation) =>
                    {
                        Expression<Func<RegisteredPlayersEntity, bool>> predicate = x => x.PlayerEmail == playerEmail;
                        var isExist = await _registeredPlayersRepository.RegisteredPlayersRead.IsAnyAsync(predicate);
                        if (isExist)
                        {
                            return false;
                        }
                        return true;
                    }).WithMessage("This Email is already exist.");
            });
    }
}

