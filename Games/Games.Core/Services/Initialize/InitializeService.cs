using Games.Infrastructure;

namespace Games.Core.Services;

public class InitializeService : IInitializeService
{
    private readonly ITicTacToeRepository _ticTacToeRepository;
    private readonly IPlayTicTacToeService _playTicTacToeService;
    public InitializeService(
        ITicTacToeRepository ticTacToeRepository, IPlayTicTacToeService playTicTacToeService)
    {
        _ticTacToeRepository = ticTacToeRepository;
        _playTicTacToeService = playTicTacToeService;
    }

    public async Task<InitializeGameResponse> Initialize(InitializeGameRequest initializeGame)
    {
        int gameId = 0;
        Dictionary<string, string> possibleMoves = new();
        if (GameType.TicTacToe.GetGameType(initializeGame.GameType))
        {
            gameId = await _ticTacToeRepository.InsertAndGetIdGameAsync(initializeGame.SetGameEntity());
            // 
            var taskUpdate = _ticTacToeRepository.UpdateScoreTableTotalGamesAsync(initializeGame);
            // 
            possibleMoves = _playTicTacToeService.SetInitialPossibleMovesTicTacToe(initializeGame.GameOptions.TicTacToeNumberColumns);
            await taskUpdate;
        }
        if (GameType.TicTacToe.GetGameType(initializeGame.GameType))
        {
            // 
        }
        if (gameId <= 0)
        {
            return null;
        }
        return new InitializeGameResponse(idGame: gameId, startGame: true, possibleMoves: possibleMoves);
    }
}
