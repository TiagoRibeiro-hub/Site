namespace TicTacToe.Services
{
    public interface IGameService
    {
        Task<GameResponse> InitializeGameAsync(RegisterPlayersRequest registerPlayers);
        Task<GameResponse> GamePlayedAsync(GameRequest game);
        Task<GameResponse> GamePlayedAiAsync(GameComputerRequest game);
    }
}
