using ApiShared;

namespace Games.Core.Services;
public interface IGameService
{
    Task<GameResponse?> InitializeVsHuman(RegisterVsHuman request, string gameType);
    Task<GameVsComputerResponse?> InitializeVsComputer(RegisterVsComputer request, string gameType);

    Task<ResponseError> MoveValidation(GameVsHumanRequest game, string gameType);
    Task<GameResponse?> PlayVsHuman(GameVsHumanRequest request, string gameType);

    Task<GameVsComputerResponse?> PlayVsComputer(GameVsComputerRequest request, string gameType);
}

