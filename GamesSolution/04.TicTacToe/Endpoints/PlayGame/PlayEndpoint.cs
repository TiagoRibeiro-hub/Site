using _00.Data.Api.PlayGame;
using _06.TicTacToe.Infrastructure;

namespace _04.TicTacToe._03.Web.Endpoints.PlayGame;
public static class PlayEndpoint
{
    public static void MapPlayEndpoints(this WebApplication app)
    {
        app.MapPost("/play", Play);
    }
    internal static IResult Play(PlayTicTacToeRecord playTicTacToe)
    {
        PlayResponse response = new();

        return response is not null ? Results.Ok(response) : Results.BadRequest(response);
    }
}

