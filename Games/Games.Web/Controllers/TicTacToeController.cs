using ApiShared;
using Games.Core.Services;
using Games.Data.Api;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TicTacToeController : BaseController
{
    private readonly IGamePhasesService _gamePhasesService;

    public TicTacToeController(IGamePhasesService gamePhasesService) : base(gamePhasesService)
    {
        _gamePhasesService = gamePhasesService;
    }
    public override async Task<IActionResult> Play<TEntity>([FromBody] TEntity request)
    {
        try
        {
            var result = await _gamePhasesService.Play(request);
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
