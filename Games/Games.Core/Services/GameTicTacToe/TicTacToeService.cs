using Games.Infrastructure;
using Repository;

namespace Games.Core.Services;

public class TicTacToeService : ITicTacToeService
{
    public async Task<InitializeGameResponse> Initialize(InitializeGameRequest initializeGame)
    {
        Response<InitializeGameResponse> response = new();
        GameEntity game = initializeGame.SetGameEntity();
        int gameId = 1; //await _repository.InsertAndGetIdAsync(game);
        if (gameId <= 0)
        {
            return null;
        }
        bool isRegistered = false;
        if (initializeGame.VsComputer.IsComputer)
        {
            ScoresTableEntity scores = initializeGame.SetScoreTableVsComputer();
            //_repository.InsertAsync(scores);
        }
        else
        {

        }
        return new InitializeGameResponse(idGame: gameId, startGame: true);

    }

    public Task<Response?> Play(PlayRequest playRequest)
    {
        throw new NotImplementedException();
    }
}


