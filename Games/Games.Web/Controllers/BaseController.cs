using ApiShared;
using Games.Core.Services;
using Games.Data.Api;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    private readonly IGamePhasesService _gameService;
    public BaseController(IGamePhasesService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost("[action]")]
    [ProducesResponseType(200, Type = typeof(Response<RegisterPlayerResponse>))]
    [ProducesResponseType(400, Type = typeof(Response<Error>))]
    [ProducesResponseType(500, Type = typeof(Response<Exception>))]
    public async Task<Response> RegisterPlayer([FromBody] Request<RegisterPlayerRequest> request)
    {
        Response response = new();
        try
        {
            return await _gameService.RegisterPlayer(request.Content);
        }
        catch (Exception ex)
        {
            return response.Fail(ApiSharedConst.SomethingWentWrong, ex);
        }
    }

    [HttpPost("[action]")]
    [ProducesResponseType(200, Type = typeof(Response<InitializeGameRequest>))]
    [ProducesResponseType(400, Type = typeof(Response<Error>))]
    [ProducesResponseType(500, Type = typeof(Response<Exception>))]
    public async Task<Response> Initialize([FromBody] Request<InitializeGameRequest> request)
    {
        Response response = new();
        try
        {
            return await _gameService.Initialize(request.Content);
        }
        catch (Exception ex)
        {
            return response.Fail(ApiSharedConst.SomethingWentWrong, ex);
        }
    }

    [HttpPost("[action]")]
    [ProducesResponseType(200, Type = typeof(Response<PlayRequest>))]
    [ProducesResponseType(400, Type = typeof(Response<Error>))]
    [ProducesResponseType(500, Type = typeof(Response<Exception>))]
    public async Task<Response> Play([FromBody] Request<PlayRequest> request)
    {
        Response response = new();
        try
        {
            return await _gameService.Play(request.Content);

        }
        catch (Exception ex)
        {
            return response.Fail(ApiSharedConst.SomethingWentWrong, ex);
        }
    }
}

