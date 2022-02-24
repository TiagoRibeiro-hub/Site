using Games.Core.Services;
using Games.Data.Api;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ChessController : BaseController
{
    public ChessController(IGamePhasesService gamePhasesService) : base(gamePhasesService)
    {

    }

}