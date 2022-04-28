using _01.Game.Initialize.Infrastructure;
using _02.Game.Initialize.Core.Services;
using ApiShared;

namespace Game.Initialize.Endpoints;
    public static class InitializeGameEndpoints
{
    public static void MapInitializeGameEndpoints(this WebApplication app)
    {
        app.MapPost("/initializegame", SetInitializeGame);
    }
    internal static async Task<IResult> SetInitializeGame(
        IInitializeGameService initializeGameService, InitializeGameRecord game)
    {
        try
        {
            Response response = await initializeGameService.SetSetInitializeGameResponse(game);

            return response is null || response.GetType() == typeof(Response<Error>)
                ? Results.BadRequest(response)
                : Results.Ok(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
}

