using ApiShared;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Services;

namespace TicTacToe.Controllers
{
    [ApiController]
    public class TicTacToeController : ControllerBase
    {
        private readonly IGameService _gameService;

        public TicTacToeController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(Response<GameResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> InitializeGame([FromBody] Request<RegisterPlayersRequest> request)
        {
            try
            {
                if (request.Content is null)
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull);
                }

                GameResponse gameResponse = await _gameService.InitializeGameAsync(request.Content);
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
        [ProducesResponseType(200, Type = typeof(Response<GameResponse>))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> GamePlay([FromBody] Request<GameRequest> request)
        {
            try
            {
                if (request.Content is null)
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull);
                }
                if (request.Content.IsComputer)
                {
                    return new ResponseError(ApiSharedFuncs.SetApisWrongEndPoint("This is the human player"));
                }
                if (int.Parse(request.Content.MoveTo) < 1 || int.Parse(request.Content.MoveTo) > 9)
                {
                    return new ResponseError("Possible moves between 1 & 9");
                }
                if (request.Content.PossibleMoves.Contains(int.Parse(request.Content.MoveTo)) == false)
                {
                    return new ResponseError($"{request.Content.MoveTo} has already been played");
                }

                GameResponse gameResponse = await _gameService.GamePlayedAsync(request.Content);
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
        public async Task<Response> GamePlayComputer([FromBody] Request<GameComputerRequest> request)
        {
            try
            {
                if (request.Content is null)
                {
                    return new ResponseError(ApiSharedFuncs.RequestIsNull);
                }
                if (!request.Content.IsComputer)
                {
                    return new ResponseError(ApiSharedFuncs.SetApisWrongEndPoint("This is the computer player"));
                }

                GameResponse gameResponse = await _gameService.GamePlayedAiAsync(request.Content);
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