using _00.Data._Entities;
using _00.Data.Api.InitializeGame;
using _05.TicTacToe.Core.Repository;
using _06.TicTacToe.Infrastructure;

namespace _05.TicTacToe.Core.InitializeGameService;
public class InitializeGame : IInitializeGameService
{
    private readonly ITicTacToeRepository _ticTacToeRepository;

    public InitializeGame(ITicTacToeRepository ticTacToeRepository)
    {
        _ticTacToeRepository = ticTacToeRepository;
    }

    public async Task<InitializeGameResponse> SetInitializeGameResponse(InitializeGameRequestRecord initializeGameRequest)
    {
        var resGameId = _ticTacToeRepository.GetTicTacToeGameWrite.InsertAndGetIdAsync(initializeGameRequest.SetGameEntity());
        Dictionary<string, string> possibleMoves = SetInitialPossibleMovesTicTacToe(initializeGameRequest.TicTacToeNumberColumns);
        int gameId = await resGameId;
        return new InitializeGameResponse
            (
             idGame: gameId,
             startGame: true,
             possibleMoves: possibleMoves
            );
    }
    private Dictionary<string, string> SetInitialPossibleMovesTicTacToe(int TicTacToeNumberColumns)
    {
        int max = TicTacToeNumberColumns * TicTacToeNumberColumns + 1;
        Dictionary<string, string> result = new();
        for (int i = 1; i < max; i++)
        {
            result.Add(i.ToString(), i.ToString());
        }
        return result;
    }
}
