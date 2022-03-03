using _00.Data.Api.InitializeGame;
using _00.Data.Api.PlayerRegister;
using _00.Data.Api.PlayGame;
using ApiShared;

namespace _02.Games.Core.Services.GamePhases;

public interface IGamePhasesService
{
    Task<Response?> RegisterPlayer(RegisterPlayerRequest registerPlayer);
    Task<Response?> Initialize(InitializeGameRequest initializeGame);
    Task<Response?> Play(PlayRequest playRequest);
}
