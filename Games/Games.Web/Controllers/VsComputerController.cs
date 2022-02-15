using ApiShared;
using Games.Core.Services;
using Games.Infrastructure.Api;
using Microsoft.AspNetCore.Mvc;
#nullable disable
namespace Games.Web.Controllers
{
    [ApiController]
    [Route("[controller]/{gametype}")]
    public class VsComputerController : Controller
    {
        private readonly IGameService _gameService;
        public VsComputerController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(Response<GameVsComputerResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> Initialize(
            [FromBody] Request<RegisterVsComputer> request, 
            [FromRoute] string gameType)
        {
            try
            {
                if (request.Content is null || string.IsNullOrWhiteSpace(gameType))
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull);
                }

                GameVsComputerResponse gameResponse = await _gameService.InitializeVsComputer(request.Content, gameType);
                
                if (gameResponse is null || gameResponse.IdGame < 0)
                {
                    return new ResponseError(ApiSharedFuncs.SomethingWentWrong);
                }

                return new Response<GameVsComputerResponse>()
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
#nullable enable
    }
}
