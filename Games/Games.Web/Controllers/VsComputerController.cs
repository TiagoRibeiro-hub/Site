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
        [ProducesResponseType(500, Type = typeof(ResponseError<Exception>))]
        public async Task<Response> Initialize([FromBody] Request<RegisterVsComputer> request)
        {
            Response response = new(); ResponseError responseError = new();
            try
            {
                if (request.Content is null || string.IsNullOrWhiteSpace(request.Content.GameType))
                {
                    return responseError.Fail(ApiSharedConst.RequestIsNull);
                }

                GameVsComputerResponse gameResponse = await _gameService.InitializeVsComputer(request.Content);
                
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
        [ProducesResponseType(200, Type = typeof(Response<GameVsComputerResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseError<Exception>))]
        public async Task<Response> Play([FromBody] Request<GameVsComputerRequest> request)
        {
            Response response = new(); ResponseError responseError = new();
            try
            {
                if (request.Content is null)
                {
                    return responseError.Fail(ApiSharedConst.RequestIsNull);
                }
                if (!request.Content.IsComputer)
                {
                    return responseError.Fail(ApiSharedFuncs.SetApisWrongEndPoint("This is the computer player"));
                }

                GameVsComputerResponse gameResponse = await _gameService.PlayVsComputer(request.Content);
                if (gameResponse is null)
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
#nullable enable
    }
}
