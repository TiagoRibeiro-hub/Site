namespace Games.Core.Services;
public interface IGameTicTacToeService
{
    Task<GameResponse> InitializeGameVsHumanAsync(RegisterVsHuman request);
    Task<GameVsComputerResponse> InitializeGameVsComputerAsync(RegisterVsComputer request);
}
