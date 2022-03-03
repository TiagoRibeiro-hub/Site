using _00.Data.Api.InitializeGame;

namespace _02.Games.Core.Services._03_InitializePhase;

public interface IInitializePhaseService
{
    Task<InitializeGameResponse> Initialize(InitializeGameRequest initializeGame);
}