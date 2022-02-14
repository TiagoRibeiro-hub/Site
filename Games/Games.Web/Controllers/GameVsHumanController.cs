using ApiShared;
using Games.Core.Services;
using Games.Infrastructure.Api;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers
{
    [ApiController]
    [Route("[controller]/{gametype}")]
    public class GameVsHumanController : Controller
    {       
        private readonly IGameService _gameService;
        public GameVsHumanController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(Response<GameResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> Initialize(
            [FromBody] Request<RegisterVsHuman> request, 
            [FromRoute] string gameType)
        {
            try
            {
                if (request.Content is null || string.IsNullOrWhiteSpace(gameType))
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull);
                }

                GameResponse gameResponse = await _gameService.InitializeVsHuman(request.Content, gameType);
                if (gameResponse is null || gameResponse.IdGame < 0)
                {
                    return new ResponseError(ApiSharedFuncs.SomethingWentWrong);
                }

                return new Response<GameResponse>()
                {
                    Content = gameResponse,
                };

            }
            catch (Exception ex)
            {
                HashSet<string> errors = ApiSharedFuncs.GetListErrord(ex);
                return new ResponseErrorException(errors, ex.InnerException.ToString());
            }
        }

      
    }
}
