using _00.Data.Api.InitializeGame;
using _00.Data.Api.PlayerRegister;
using _02.Games.Core.Services.GamePhases;
using ApiShared;
using Microsoft.AspNetCore.Mvc;

namespace _03.Games.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamePhasesService _gamePhasesService;
        public GamesController(IGamePhasesService gameService)
        {
            _gamePhasesService = gameService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterPlayer([FromBody] Request<RegisterPlayerRequest> request)
        {
            try
            {
                var result = await _gamePhasesService.RegisterPlayer(request.Content);
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
    }
}