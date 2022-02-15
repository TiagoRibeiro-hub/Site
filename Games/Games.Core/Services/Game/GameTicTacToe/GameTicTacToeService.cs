using Games.Data.Api;
using Games.Data.Extensions;
using Games.Infrastructure.RepositoryService;

namespace Games.Core.Services;
public class GameTicTacToeService : IGameTicTacToeService
{
    private readonly IRepository _repository;
    private readonly IScoreTableService _scoreTableService;
    private readonly GameFuncs _gameFuncs;

    public GameTicTacToeService(IRepository repository, IScoreTableService scoreTableService, GameFuncs gameFuncs)
    {
        _repository = repository;
        _scoreTableService = scoreTableService;
        _gameFuncs = gameFuncs;
    }

    #region Human

    public async Task<GameResponse> InitializeGameVsHumanAsync(RegisterVsHuman request)
    {
        GameEntity game = request.SetGameEntityVsHuman();
        HashSet<ScoresTableEntity> scoresTablesList = request.SetScoreTableVsHuman();
        int idGame = await _repository.InsertAndGetIdAsync(game);
        var res = _scoreTableService.TableScoreInitializeList(scoresTablesList, game);
        Dictionary<string, string> possibleMoves = _gameFuncs.SetInitialPossibleMovesTicTacToe();
        await res;
        return new GameResponse(idGame: idGame, possibleMoves: possibleMoves);
    }

    public async Task<GameResponse> PlayVsHumanAsync(GameVsHumanRequest request)
    {
        MovesEntity moves = request.SetMovesEntityVsHuman();
        var res = _repository.InsertAsync(moves);
        request.PossibleMoves.Remove(request.MoveTo);
        await res;
        GameResponse gameResponse = await _gameFuncs.GetWinnerAsync(request);
        return gameResponse;
    }

    #endregion

    #region Computer

    public async Task<GameVsComputerResponse> InitializeGameVsComputerAsync(RegisterVsComputer request)
    {
        GameEntity game = request.SetGameEntityVsComputer();
        ScoresTableEntity scoresTable = request.SetScoreTableVsComputer();
        int idGame = await _repository.InsertAndGetIdAsync(game);
        var res = _scoreTableService.TableScoreInitialize(scoresTable, game);
        Dictionary<string, string> possibleMoves = _gameFuncs.SetInitialPossibleMovesTicTacToe();
        await res;
        return new GameVsComputerResponse(idGame: idGame, possibleMoves: possibleMoves);
    }

    public Task<GameVsComputerResponse> PlayVsComputerAsync(GameVsComputerRequest request)
    {
        throw new NotImplementedException();
    }

    #endregion

}

