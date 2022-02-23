using ApiShared;
using Games.Core.Services;
using Games.Core.Validators;
using Games.Data.Api;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers;
#nullable disable

[ApiController]
public abstract class BaseController : ControllerBase
{
    private readonly IGamePhasesService _gamePhasesService;
    public BaseController(IGamePhasesService gameService)
    {
        _gamePhasesService = gameService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterPlayer([FromBody] Request<RegisterPlayerRequest> request)
    {
        try
        {
            var result = await _gamePhasesService.RegisterPlayer(request.Content);
            if(result.GetType() == typeof(Response<Error>))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            Response response = new();
            response.Fail(ApiSharedConst.SomethingWentWrong, ex);
            return StatusCode(500, response);
        }
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Initialize([FromBody] Request<InitializeGameRequest> request)
    {
        try
        {
            var result = await _gamePhasesService.Initialize(request.Content);
            if (result.GetType() == typeof(Response<Error>))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            Response response = new();
            response.Fail(ApiSharedConst.SomethingWentWrong, ex);
            return StatusCode(500, response);
        }
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Play([FromBody] Request<PlayRequest> request)
    {
        try
        {
            var result = await _gamePhasesService.Play(request.Content);
            if (result.GetType() == typeof(Response<Error>))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            Response response = new();
            response.Fail(ApiSharedConst.SomethingWentWrong, ex);
            return StatusCode(500, response);
        }
    }
}

