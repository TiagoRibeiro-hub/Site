using _00.Data.Api.InitializeGame;
using _06.TicTacToe.Infrastructure;

namespace _05.TicTacToe.Core.InitializeGameService;

public interface IInitializeGameService
{
    Task<InitializeGameResponse> SetInitializeGameResponse(InitializeGameRequestRecord initializeGameRequest);
}
