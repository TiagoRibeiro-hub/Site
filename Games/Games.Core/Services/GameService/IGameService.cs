namespace Games.Core.Services;
public interface IGameService
{
    Task<GameResponse> InitializeGameVsHuman(RegisterVsHuman request, GameType gameType);
    Task<GameVsComputerResponse> InitializeGameVsComputer(RegisterVsComputer request, GameType gameType);
}

