namespace Games.Core.Funcs;

public class WinnerFuncs
{

    private Expression<Func<MovesEntity, bool>>? _expressionBool;
    private Expression<Func<MovesEntity, string>>? _expressionString;
    
    public async Task<PlayResponse> GetWinnerTicTacToe(PlayRequest request)
    {
        //_expressionBool = x => x.GameId == request.IdGame && x.PlayerName == request.Player.Name;
        //_expressionString = x => x.MoveTo;
        //var playerMoves = await _readRepository.GetSelectedTableToListAsync(_expressionBool, _expressionString);
        //bool haveWinner = WinnerCheckTictacToe.HaveWinner(playerMoves, request.TicTacToeNrCol);
        //GameResponse gameResponse = request.SetGameResponse();
        //if (haveWinner)
        //{
        //    gameResponse.GameState = GameState.Finished.GameStateToString();
        //    gameResponse.GameResult = GameResult.Winner.GameResultToString();
        //}
        //else
        //{
        //    (gameResponse.GameState, gameResponse.GameResult) = WinnerCheckTictacToe.IsFinished(request.PossibleMoves.Count);
        //}
        //return gameResponse;
        throw new NotImplementedException();
    }


}
