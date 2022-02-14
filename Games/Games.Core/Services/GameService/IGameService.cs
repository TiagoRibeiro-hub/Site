namespace Games.Core.Services;
public interface IGameService
{
    Task<GameResponse?> InitializeVsHuman(RegisterVsHuman request, string gameType);
    Task<GameVsComputerResponse?> InitializeVsComputer(RegisterVsComputer request, string gameType);
}

