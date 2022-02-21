namespace Games.Core.Services;
public class GameTicTacToeService
{

    #region Human

    //public async Task<GameResponse> InitializeGameVsHumanAsync(RegisterVsHuman request)
    //{
    //    GameEntity game = request.SetGameEntityVsHuman();
    //    HashSet<ScoresTableEntity> scoresTablesList = request.SetScoreTableVsHuman();
    //    int idGame = await _repository.InsertAndGetIdAsync(game);
    //    var res = _scoreTableService.TableScoreInitializeList(scoresTablesList, game);
    //    Dictionary<string, string> possibleMoves = _gameFuncs.SetInitialPossibleMovesTicTacToe(request.TicTacToeNrCol);
    //    await res;
    //    return new GameResponse
    //        (
    //            idGame: idGame,
    //            gameState: GameState.Start.GameStateToString(),
    //            possibleMoves: possibleMoves,
    //            ticTacToeNrCol: request.TicTacToeNrCol
    //        );
    //}
    //    public async Task<GameResponse> PlayVsHumanAsync(GameVsHumanRequest request)
    //    {
    //        MovesEntity moves = request.SetMovesEntityVsHuman();
    //        var res = _repository.InsertAsync(moves);
    //        request.PossibleMoves.Remove(request.MoveTo);
    //        await res;
    //#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    //        GameResponse gameResponse = await _gameFuncs.GetWinnerAsync(request);
    //#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    //        if (gameResponse == null)
    //        {
    //            throw new Exception();
    //        }
    //        return gameResponse;
    //    }

    #endregion

    #region Computer

    //public async Task<GameVsComputerResponse> InitializeGameVsComputerAsync(RegisterVsComputer request)
    //{
    //    GameEntity game = request.SetGameEntityVsComputer();
    //    ScoresTableEntity scoresTable = request.SetScoreTableVsComputer();
    //    int idGame = await _repository.InsertAndGetIdAsync(game);
    //    var res = _scoreTableService.TableScoreInitialize(scoresTable, game);
    //    Dictionary<string, string> possibleMoves = _gameFuncs.SetInitialPossibleMovesTicTacToe(request.TicTacToeNrCol);
    //    await res;
    //    return new GameVsComputerResponse
    //        (
    //            idGame: idGame,
    //            player: request.Player.Name,
    //            gameState: GameState.Start.GameStateToString(),
    //            gameResult: null,
    //            possibleMoves: possibleMoves,
    //            ticTacToeNrCol: request.TicTacToeNrCol,
    //            difficulty: request.Difficulty.ToUpper()
    //        );
    //}
    //public Task<GameVsComputerResponse> PlayVsComputerAsync(GameVsComputerRequest request)
    //{
    //    throw new NotImplementedException();
    //}

    #endregion

}
