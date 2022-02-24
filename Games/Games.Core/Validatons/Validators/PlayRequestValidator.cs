using FluentValidation;


namespace Games.Core.Validators;

public class PlayRequestValidator : AbstractValidator<PlayRequest>
{
    public PlayRequestValidator(int gameId)
    {
        RuleFor(x => x.GameType)
            .SetValidator(x => new GameOptionsValidator(x.GameType.GameTypeName))
            .DependentRules(() =>
            {
                // GameTypeOptions And Players
                // if TicTacToe
                When(x => x.GameType.GameTypeName.ToUpper() == GameType.TicTacToe.GameTypeToStringUpper(), () =>
                {
                    PlayRules(gameId, GameType.TicTacToe.GameTypeToStringUpper());
                });

                // if Chess
                When(x => x.GameType.GameTypeName.ToUpper() == GameType.Chess.GameTypeToStringUpper(), () =>
                {
                    PlayRules(gameId, GameType.Chess.GameTypeToStringUpper());
                });
            });
    }

    private void PlayRules(int gameId, string gameType)
    {
        // Id Game
        RuleFor(x => x.IdGame)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().NotNull()
            .GreaterThan(0)
            .DependentRules(() =>
            {
                // PossibleMoves
                RuleFor(x => x.PossibleMoves)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().NotNull()
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.VsComputer.IsComputer)
                            .Cascade(CascadeMode.Stop)
                            .NotEmpty().NotNull()
                            .DependentRules(() =>
                            {
                                // human playing
                                Unless(x => x.VsComputer.IsComputer == false, () =>
                                {
                                        // Movement
                                        RuleFor(x => x.Movements)
                                            .SetValidator(new MovementValidator(gameType))
                                            .DependentRules(() =>
                                            {
                                                // PlayerName confirmar se pertence ao jogo
                                                RuleFor(x => x.PlayerName).PlayerNameRule().IsPlayerBelongToGameWithMessage(gameId);
                                            });      
                                }).Otherwise(() =>
                                {
                                    RuleFor(x => x.VsComputer.Difficulty).IsDifficultyExistWithMessage();
                                });
                            });
                    });
            });
    }
}
