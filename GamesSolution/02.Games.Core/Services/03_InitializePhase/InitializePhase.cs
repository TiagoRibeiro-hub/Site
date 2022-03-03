using _00.Data.Api.InitializeGame;
using _00.Data.Api.TicTacToe;
using _00.Data.Enums;
using _00.Data.Extensions;
using _02.Games.Core.Services._04.HttpClientTicTacToe;

namespace _02.Games.Core.Services._03_InitializePhase;
#nullable disable
public class InitializePhase : IInitializePhaseService
{

    private readonly HttpTicTacToe _httpTicTacToe;

    public InitializePhase(HttpTicTacToe httpTicTacToe)
    {
        _httpTicTacToe = httpTicTacToe;
    }

    public async Task<InitializeGameResponse> Initialize(InitializeGameRequest initializeGame)
    {
        InitializeGameResponse initializeGameResponse = new();
        if (GameType.TicTacToe.GetGameType(initializeGame.GetGameOptions.GameTypeName))
        {
            initializeGameResponse = await _httpTicTacToe.GetTicTacToeInitializeGame(initializeGame);
        }
        if (GameType.TicTacToe.GetGameType(initializeGame.GetGameOptions.GameTypeName))
        {
            // 
        }
        if (initializeGameResponse is null || initializeGameResponse.IdGame <= 0)
        {
            return null; // Error come from DataBase 
        }
        return initializeGameResponse;
    }
}
