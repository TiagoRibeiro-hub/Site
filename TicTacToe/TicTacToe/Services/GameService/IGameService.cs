namespace TicTacToe.Services
{
    public interface IGameService
    {
        Task<int> InitializeGameAsync(RegisterPlayersRequest registerPlayers);
        Task<GameResponse> GamePlayedAsync(GameRequest game);
    }
}
