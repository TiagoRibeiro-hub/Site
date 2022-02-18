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
        [ProducesResponseType(500, Type = typeof(ResponseError<Exception>))]
        public async Task<Response> Initialize([FromBody] Request<RegisterVsHuman> request)
        {
            Response response = new(); ResponseError responseError = new();
            try
            {
                if (request.Content is null || string.IsNullOrWhiteSpace(request.Content.GameType))
                {
                    return responseError.Fail(ApiSharedConst.RequestIsNull);
                }

                GameResponse gameResponse = await _gameService.InitializeVsHuman(request.Content);
                if (gameResponse is null || gameResponse.IdGame < 0)
                {
                    return responseError.Fail(ApiSharedConst.SomethingWentWrong);
                }

                return response.Success(gameResponse, ApiSharedConst.EverthingOk);

            }
            catch (Exception ex)
            {
                return responseError.Fail(ApiSharedConst.SomethingWentWrong, ex);
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(Response<GameResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseError<Exception>))]
        public async Task<Response> Play([FromBody] Request<GameVsHumanRequest> request)
        {
            Response response = new(); ResponseError responseError = new();
            try
            {
                if (request.Content is null)
                {
                    return responseError.Fail(ApiSharedConst.RequestIsNull);
                }
                if (request.Content.IsComputer)
                {
                    return responseError.Fail(ApiSharedFuncs.SetApisWrongEndPoint("This is the human player"));
                }
                responseError = await _gameService.MoveValidation(request.Content);
                if(responseError.IsSuccess)
                {
                    GameResponse gameResponse = await _gameService.PlayVsHuman(request.Content);
                    if (gameResponse is null)
                    {
                        return responseError.Fail(ApiSharedConst.SomethingWentWrong);
                    }
                    return response.Success(gameResponse, ApiSharedConst.EverthingOk);
                }
                return responseError;
            }
            catch (Exception ex)
            {
                return responseError.Fail(ApiSharedConst.SomethingWentWrong, ex);
            }
        }
#nullable enable
    }
}
