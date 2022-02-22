namespace Games.Core.Services;

public interface IRegisterPlayerService
{
    Task<Response> RegisterPlayer(RegisterPlayerRequest registerPlayer);
}