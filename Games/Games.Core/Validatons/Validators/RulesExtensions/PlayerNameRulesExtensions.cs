using FluentValidation;
using Games.Infrastructure;

namespace Games.Core.Validators;

public static class PlayerNameRulesExtensions
{
    public static IRuleBuilderOptions<T, string> PlayerNameRule<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().NotNull()
            .MinimumLength(3).MaximumLength(20)
            .Matches("^[a-zA-Z0-9 ]*$")
            .WithMessage("Player name just allow letters, numbers and space");
    }

    public static IRuleBuilderOptions<T, string> IsPlayerAllowedToPlayWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder,
        ITicTacToeReadRepository ticTacToeReadRepository, GameType gameType)
    {
        return ruleBuilder.MustAsync(async (playerName, cancellation) =>
        {
            Expression<Func<ScoresTableEntity, bool>> predicate = x => x.PlayerName == playerName;
            bool isExist = false;
            if (gameType == GameType.TicTacToe)
            {
                isExist = await ticTacToeReadRepository.IsAnyInScoresTableAsync(predicate);
            }
            if (gameType == GameType.Chess)
            {
                //
            }
            if (isExist)
            {
                return true;
            }
            return false;
        }).WithMessage("This player is not allowed to play.");
    }

    public static IRuleBuilderOptions<T, string> IsPlayerBelongToGameWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder,
        ITicTacToeReadRepository ticTacToeReadRepository, int gameId, GameType gameType)
    {
        return ruleBuilder.MustAsync(async (playerName, cancellation) =>
        {
            Expression<Func<GameEntity, bool>> predicate = x => x.Id == gameId && (x.Player1_Name == playerName || x.Player2_Name == playerName);
            bool isExist = false;
            if (gameType == GameType.TicTacToe)
            {
                isExist = await ticTacToeReadRepository.IsAnyGameAsync(predicate);
            }
            if (gameType == GameType.Chess)
            {
                //
            }
            if (isExist)
            {
                return true;
            }
            return false;
        }).WithMessage("This player is not allowed to play.");
    }
}