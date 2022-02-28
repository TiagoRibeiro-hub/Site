using Games.Core.TicTacToeService.Winner;
using Games.Infrastructure;

namespace Games.Core.Services;

public class TicTacToeImplementation : ITicTacToeService
{
    private readonly ITicTacToeWriteRepository _ticTacToeWriteRepository;
    private readonly ITicTacToeReadRepository _ticTacToeReadRepository;
    public TicTacToeImplementation(
        ITicTacToeWriteRepository ticTacToeRepository, ITicTacToeReadRepository ticTacToeReadRepository)
    {
        _ticTacToeWriteRepository = ticTacToeRepository;
        _ticTacToeReadRepository = ticTacToeReadRepository;
    }
    public async Task<int> InsertAndGetIdGameAsync(GameEntity entity)
    {
        return await _ticTacToeWriteRepository.InsertAndGetIdGameAsync(entity);
    }

    public async Task UpdateScoreTableTotalGamesAsync(InitializeGameRequest initializeGame)
    {
        await ScoreTableUpdate(initializeGame, initializeGame.PlayerName_1);
        if (initializeGame.VsComputer.IsComputer == false)
        {
            await ScoreTableUpdate(initializeGame, initializeGame.VsHuman.PlayerName_2);
        }
    }
    private async Task ScoreTableUpdate(InitializeGameRequest initializeGame, string playerName)
    {
        Expression<Func<ScoresTableEntity, int>> selector = x => x.Id;
        Expression<Func<ScoresTableEntity, bool>> predicate = x => x.PlayerName == playerName;
        int scoreTableId = 1;
        await _ticTacToeWriteRepository.UpdateScoreTableTotalGamesAsync(initializeGame.SetTotalGamesUpdate(playerName, scoreTableId));
    }
    public Dictionary<string, string> SetInitialPossibleMovesTicTacToe(int TicTacToeNumberColumns)
    {
        int max = TicTacToeNumberColumns * TicTacToeNumberColumns + 1;
        Dictionary<string, string> result = new();
        for (int i = 1; i < max; i++)
        {
            result.Add(i.ToString(), i.ToString());
        }
        return result;
    }
    public async Task<List<string>> PlayMove(PlayRequest request)
    {
        request.PossibleMoves.Remove(request.Movements.MoveTo);
        MovesEntity movesEntity = request.SetMovesEntity();
        await _ticTacToeWriteRepository.InsertMovesAsync(movesEntity);
        
        Expression<Func<MovesEntity, bool>> predicate = x => x.GameId == request.IdGame && x.PlayerName == request.PlayerName;
        Expression<Func<MovesEntity, string>> selector = x => x.MoveTo;
        return await _ticTacToeReadRepository.GetToListAsync(predicate, selector);
    }

    public async Task<PlayResponse> GetWinner(PlayRequest request, List<string> playerMoves)
    {   
        bool haveWinner = WinnerCheckTicTacToe.HaveWinner(playerMoves, request.GetGameType.GetGameTypeOptions.TicTacToeNumberColumns);

        PlayResponse playResponse = request.SetPlayResponse();
        if (haveWinner)
        {
            playResponse.GameState = GameState.Finished.GameStateToStringUpper();
            playResponse.GameResult = GameResult.Winner.GameResultToStringUpper();
        }
        else
        {
            (playResponse.GameState, playResponse.GameResult) = WinnerCheckTicTacToe.IsFinished(request.PossibleMoves.Count);
        }
        return playResponse;
    }
}