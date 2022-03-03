using _00.Data.Api.PlayerRegister;
using ApiShared;

namespace _02.Games.Core.Services.RegisterPlayerPhase;

public interface IRegisterPlayerPhaseService
{
    Task<Response> RegisterPlayer(RegisterPlayerRequest registerPlayer);
}