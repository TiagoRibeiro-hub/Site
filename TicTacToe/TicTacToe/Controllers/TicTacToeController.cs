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
        public async Task<StatusCodeResult> InitializeGame([FromBody] RegisterPlayersRequest request)
        {
            try
            {
                if (request is null)
                {
                    throw new ArgumentNullException(nameof(request));
                }
                await _repository.RegisterPlayers(request);
                
                return StatusCode(200);
            }
            catch (Exception)
            {
                throw;
            }     
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<Response> GamePlay([FromBody] GameRequest request)
        {
            return new Response();
        }

    }
}