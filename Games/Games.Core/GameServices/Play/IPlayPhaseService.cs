namespace Games.Core.Services;

public interface IPlayPhaseService
{
    Task<PlayResponse> Play(PlayRequest request);
}