namespace Games.Core.Services;
public interface IGameTicTacToeService
{
    Task<GameResponse> InitializeGameVsHumanAsync(RegisterVsHuman request);
    Task<GameResponse> PlayVsHumanAsync(GameVsHumanRequest request);

    Task<GameVsComputerResponse> InitializeGameVsComputerAsync(RegisterVsComputer request);
    Task<GameVsComputerResponse> PlayVsComputerAsync(GameVsComputerRequest request);
}
