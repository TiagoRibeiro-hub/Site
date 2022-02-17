namespace Games.Core.Services;
public interface IGameService
{
    Task<GameResponse?> InitializeVsHuman(RegisterVsHuman request);
    Task<GameVsComputerResponse?> InitializeVsComputer(RegisterVsComputer request);

    Task<ResponseError> MoveValidation(GameVsHumanRequest game);
    Task<GameResponse?> PlayVsHuman(GameVsHumanRequest request);

    Task<GameVsComputerResponse?> PlayVsComputer(GameVsComputerRequest request);
}

