using _01.Games.RegisterPlayer.Infrastructure;
using _02.Games.RegisterPlayer.Core.Services;
using ApiShared;

namespace Game.RegisterPlayer.Endpoints;
public static class RegisterPlayerEndpoint
{
    public static void MapRegisterPlayerEndpoints(this WebApplication app)
    {
        app.MapPost("/registerplayer", SetRegisterPlayer);
    }
    internal static async Task<IResult> SetRegisterPlayer(IRegisterPlayerService registerPlayerService, RegisterPlayerRecord registerPlayer)
    {
        try
        {
            Response response = await registerPlayerService.SetRegisterPlayerResponse(registerPlayer);
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

