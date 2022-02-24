using Games.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ChessController : BaseController
{
    private readonly IGamePhasesService _gamePhasesService;

    public ChessController(IGamePhasesService gamePhasesService) : base(gamePhasesService)
    {
        _gamePhasesService = gamePhasesService;
    }

    public override Task<IActionResult> Play<TEntity>([FromBody] TEntity request)
    {
        throw new NotImplementedException();
    }
}