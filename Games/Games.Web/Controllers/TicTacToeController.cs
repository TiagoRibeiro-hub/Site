using Games.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TicTacToeController : BaseController
{
    public TicTacToeController(IGameService gameService) : base(gameService)
    {
    }
}
