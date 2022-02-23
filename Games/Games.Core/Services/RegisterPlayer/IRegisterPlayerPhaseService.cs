namespace Games.Core.Services;

public interface IRegisterPlayerPhaseService
{
    Task<Response> RegisterPlayer(RegisterPlayerRequest registerPlayer);
}