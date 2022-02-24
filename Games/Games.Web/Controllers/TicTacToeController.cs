using ApiShared;
using Games.Core.Services;
using Games.Data.Api;
using Microsoft.AspNetCore.Mvc;

namespace Games.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TicTacToeController : BaseController
{
    public TicTacToeController(IGamePhasesService gamePhasesService) : base(gamePhasesService)
    {

    }
}
