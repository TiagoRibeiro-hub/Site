using Games.Infrastructure;

namespace Games.Core.Services;
public class GameTicTacToeService : IGameTicTacToeService
{
    private readonly ITicTacToeService _ticTacToeService;

    public GameTicTacToeService(ITicTacToeService ticTacToeService)
    {
        _ticTacToeService = ticTacToeService;
    }

    public async Task<InitializeGameResponse> Initialize(InitializeGameRequest initializeGame)
    {
        int gameId = await _ticTacToeService.InsertAndGetIdGameAsync(initializeGame.SetGameEntity());
        // 
        var taskUpdate = _ticTacToeService.UpdateScoreTableTotalGamesAsync(initializeGame);
        // 
        Dictionary<string, string> possibleMoves = _ticTacToeService.SetInitialPossibleMovesTicTacToe(initializeGame.GameType.GetGameTypeOptions.TicTacToeNumberColumns);
        await taskUpdate;
        return new InitializeGameResponse(idGame: gameId, startGame: true, possibleMoves: possibleMoves);
    }

}
