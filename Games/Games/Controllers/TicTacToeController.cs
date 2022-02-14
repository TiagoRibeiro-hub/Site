using ApiShared;
using Games.Core.Services;
using Games.Infrastructure.Api;
using Games.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers;

[ApiController]
[Route("tictactoe")]
public class TicTacToeController : BaseController
{
    public TicTacToeController(IGameService gameService) : base(gameService)
    {
    }
}
