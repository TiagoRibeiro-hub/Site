using ApiShared;
using Games.Core.Services;
using Games.Infrastructure.Api;
using Games.Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly IGameService _gameService;

        public BaseController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(Response<GameResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> InitializeGameVsHuman([FromBody] Request<RegisterVsHuman> request)
        {
            try
            {
                if (request.Content is null)
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull);
                }

                GameResponse gameResponse = await _gameService.InitializeGameVsHuman(request.Content, GameType.TicTacToe);
                if (gameResponse.IdGame < 0)
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

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(Response<GameVsComputerResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> InitializeGameVsComputer([FromBody] Request<RegisterVsComputer> request)
        {
            try
            {
                if (request.Content is null)
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull);
                }

                GameVsComputerResponse gameResponse = await _gameService.InitializeGameVsComputer(request.Content, GameType.TicTacToe);

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
    }
}
