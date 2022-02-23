using Games.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ChessController : BaseController
{
    public ChessController(IGamePhasesService gameService) : base(gameService)
    {
    }
}