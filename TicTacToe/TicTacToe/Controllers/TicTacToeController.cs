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

        [HttpGet("InitializeGame")]
        public async Task<Response> InitializeGame([FromBody] RegisterPlayersRequest request)
        {
            if(request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var res = _repository.RegisterPlayers(request);

            Response response = await res;

            return response;
        }

        [HttpGet("GamePlay")]
        public async Task<Response> GamePlay([FromBody] RegisterPlayersRequest request)
        {
            return new Response();
        }

    }
}