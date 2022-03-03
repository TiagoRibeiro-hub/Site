using _00.Data.Game.Player;
using _01.Games.Data._DbContext;
using _02.Games.Core.Repository;
using FluentValidation;
using System.Linq.Expressions;

namespace _02.Games.Core.Validations;

public class PlayerValidator : AbstractValidator<Player>
{
    public PlayerValidator(IRegisteredPlayersRepository _registeredPlayersRepository)
    {
        RuleFor(x => x.Name)
           .Cascade(CascadeMode.Stop)
           .PlayerNameRule()
           .MustAsync(async (playerName, cancellation) =>
           {
               Expression<Func<RegisteredPlayersEntity, bool>> predicate = x => x.PlayerName == playerName;
               var isExist = await _registeredPlayersRepository.RegisteredPlayersRead.IsAnyAsync(predicate);
               if (isExist)
               {
                   return false;
               }
               return true;
           }).WithMessage("This player name is already exist."); ;


        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotNull().NotEmpty()
            .EmailAddress()
            .MustAsync(async (email, cancellation) =>
            {
                Expression<Func<RegisteredPlayersEntity, bool>> predicate = x => x.PlayerEmail == email;
                var isExist = await _registeredPlayersRepository.RegisteredPlayersRead.IsAnyAsync(predicate);
                if (isExist)
                {
                    return false;
                }
                return true;
            })
            .WithMessage("This Email is already exist.");
    }


}


public static class PlayerNameRulesExtensions
{
    public static IRuleBuilderOptions<T, string> PlayerNameRule<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotNull().NotEmpty()
            .MinimumLength(3).MaximumLength(20)
            .Matches("^[a-zA-Z0-9 ]*$")
            .WithMessage("Player name just allow letters, numbers and space");
    }
}

