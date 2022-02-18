namespace Games.Core.Funcs;

public class WinnerFuncs
{
    private readonly IReadRepository _readRepository;

    public WinnerFuncs(IReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    private Expression<Func<MovesEntity, bool>>? _expressionBool;
    private Expression<Func<MovesEntity, string>>? _expressionString;
    
    public async Task<GameResponse> GetWinnerTicTacToe(GameVsHumanRequest request)
    {
        _expressionBool = x => x.GameId == request.IdGame && x.PlayerName == request.Player.Name;
        _expressionString = x => x.MoveTo;
        var playerMoves = await _readRepository.GetSelectedTableToListAsync(_expressionBool, _expressionString);
        bool haveWinner = WinnerCheckTictacToe.HaveWinner(playerMoves, request.TicTacToeNrCol);
        GameResponse gameResponse = new
            (
                idGame: request.IdGame,
                player: request.Player.Name,
                gameState: null,
                gameResult: null,
                possibleMoves: request.PossibleMoves,
                ticTacToeNrCol: request.TicTacToeNrCol
            );
        if (haveWinner)
        {
            gameResponse.GameState = GameState.Finished.GameStateToString();
            gameResponse.GameResult = GameResult.Winner.GameResultToString();
        }
        else
        {
            (gameResponse.GameState, gameResponse.GameResult) = WinnerCheckTictacToe.IsFinished(request.PossibleMoves.Count);
        }
        return gameResponse;
    }


}
