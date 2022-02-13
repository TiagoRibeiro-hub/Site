namespace Games.Core.Services;
public interface IGameTicTacToeService
{
    Task<GameResponse> InitializeGameVsHuman(RegisterVsHuman request);
    Task<GameVsComputerResponse> InitializeGameVsComputer(RegisterVsComputer request);
}
