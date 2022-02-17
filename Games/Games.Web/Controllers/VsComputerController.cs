using ApiShared;
using Games.Core.Services;
using Games.Data.Api;
using Microsoft.AspNetCore.Mvc;

#nullable disable
namespace Games.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<Response> Initialize([FromBody] Request<RegisterVsComputer> request)
        {
            try
            {
                if (request.Content is null || string.IsNullOrWhiteSpace(request.Content.GameType))
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull, false);
                }

                GameVsComputerResponse gameResponse = await _gameService.InitializeVsComputer(request.Content);
                
                if (gameResponse is null || gameResponse.IdGame < 0)
                {
                    return new ResponseError(ApiSharedFuncs.SomethingWentWrong, false);
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

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(Response<GameResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> Play([FromBody] Request<GameVsComputerRequest> request)
        {
            try
            {
                if (request.Content is null)
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull, false);
                }
                if (!request.Content.IsComputer)
                {
                    return new ResponseError(ApiSharedFuncs.SetApisWrongEndPoint("This is the computer player"), false);
                }

                GameResponse gameResponse = await _gameService.PlayVsComputer(request.Content);
                if (gameResponse is null)
                {
                    return new ResponseError(ApiSharedFuncs.SomethingWentWrong, false);
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
#nullable enable
    }
}
