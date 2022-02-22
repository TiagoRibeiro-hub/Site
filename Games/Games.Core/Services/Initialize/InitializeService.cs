using Games.Infrastructure;

namespace Games.Core.Services;

public class InitializeService : IInitializeService
{
    private readonly ITicTacToeRepository _ticTacToeRepository;
    public InitializeService(
        ITicTacToeRepository ticTacToeRepository)
    {
        _ticTacToeRepository = ticTacToeRepository;
    }

    public async Task<InitializeGameResponse> Initialize(InitializeGameRequest initializeGame)
    {
        int gameId = 0;
        if (GameType.TicTacToe.GetGameType(initializeGame.GameType))
        {
            gameId = await _ticTacToeRepository.InsertAndGetIdGameAsync(initializeGame.SetGameEntity());
            // update
            await _ticTacToeRepository.UpdateScoreTableTotalGamesAsync(initializeGame);
        }
        if (GameType.TicTacToe.GetGameType(initializeGame.GameType))
        {
            // 
        }
        if (gameId <= 0)
        {
            return null;
        }
        return new InitializeGameResponse(idGame: gameId, startGame: true);
    }
}
