using Games.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers
{
    [ApiController]
    [Route("chess")]
    public class ChessController : BaseController
    {
        public ChessController(IGameService gameService) : base(gameService)
        {
        }
    }
}
