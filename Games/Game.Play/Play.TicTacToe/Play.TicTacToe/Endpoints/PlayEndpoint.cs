using _01.Play.TicTacToe.Infrastructure;
using _02.Play.TicTacToe.Core.Services;
using ApiShared;

namespace Play.TicTacToe.Endpoints;
public static class PlayEndpoint
{
    public static void MapPlayEndpoints(this WebApplication app)
    {
        app.MapPost("/play", SetPlayResponse);
    }
    internal static async Task<IResult> SetPlayResponse(IPlayService playService, PlayTicTacToeRecord playTicTacToe)
    {
        try
        {
            Response response = await playService.SetPlayResponse(playTicTacToe);
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