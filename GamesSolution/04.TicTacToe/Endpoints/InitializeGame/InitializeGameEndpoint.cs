using _00.Data.Api.InitializeGame;
using _05.TicTacToe.Core.InitializeGameService;
using _06.TicTacToe.Infrastructure;

namespace _04.TicTacToe._03.Web.Endpoints.InitializeGame;

public static class InitializeGameEndpoint
{
    public static void MapInitializeGameEndpoints(this WebApplication app)
    {
        app.MapPost("/initialize", InitializeGame);
    }
    internal static async Task<IResult> InitializeGame(IInitializeGameService initializeGameService, InitializeGameRequestRecord initializeGameRequest)
    {
        try
        {
            InitializeGameResponse response = await initializeGameService.SetInitializeGameResponse(initializeGameRequest);
            return response is not null ? Results.Ok(response) : Results.BadRequest(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
}

