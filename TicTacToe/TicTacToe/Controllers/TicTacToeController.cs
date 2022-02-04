using ApiShared;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Service;

namespace TicTacToe.Controllers
{
    [ApiController]
    public class TicTacToeController : ControllerBase
    {
        private readonly IRepository _repository;

        public TicTacToeController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(GameResponse))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> InitializeGame([FromBody] RegisterPlayersRequest request)
        {
            try
            {
                if (request is null)
                {
                    throw new ArgumentNullException(nameof(request));
                }
                int gameId = await _repository.RegisterPlayers(request);
                if (gameId < 0)
                {
                    return new ResponseError(ApiSharedFuncs.SomethingWentWrong);
                }

                return new GameResponse()
                {
                    IdGame = gameId,
                }; 
            }
            catch (Exception ex)
            {
                HashSet<string> errors = ApiSharedFuncs.GetListErrord(ex);
                return new ResponseErrorException(errors, ex.InnerException.ToString());
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(GameResponse))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> GamePlay([FromBody] GameRequest request)
        {
            try
            {
                return new Response();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(GameResponse))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseErrorException))]
        public async Task<Response> GamePlayComputer([FromBody] GameRequest request)
        {
            return new Response();
        }

    }
}