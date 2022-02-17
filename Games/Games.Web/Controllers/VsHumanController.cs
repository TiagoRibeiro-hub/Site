using ApiShared;
using Games.Core.Services;
using Games.Data.Api;
using Microsoft.AspNetCore.Mvc;
#nullable disable
namespace Games.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VsHumanController : Controller
    {       
        private readonly IGameService _gameService;
        public VsHumanController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(Response<GameResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> Initialize([FromBody] Request<RegisterVsHuman> request)
        {
            try
            {
                if (request.Content is null || string.IsNullOrWhiteSpace(request.Content.GameType))
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull, false);
                }

                GameResponse gameResponse = await _gameService.InitializeVsHuman(request.Content);
                if (gameResponse is null || gameResponse.IdGame < 0)
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

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(Response<GameResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> Play([FromBody] Request<GameVsHumanRequest> request)
        {
            try
            {
                if (request.Content is null)
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull, false);
                }
                if (request.Content.IsComputer)
                {
                    return new ResponseError(ApiSharedFuncs.SetApisWrongEndPoint("This is the human player"), false);
                }
                ResponseError responseError = await _gameService.MoveValidation(request.Content);
                if(responseError.IsSuccess)
                {
                    GameResponse gameResponse = await _gameService.PlayVsHuman(request.Content);
                    if (gameResponse is null)
                    {
                        return new ResponseError(ApiSharedFuncs.SomethingWentWrong, false);
                    }
                    return new Response<GameResponse>()
                    {
                        Content = gameResponse,
                    };
                }
                return responseError;
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
