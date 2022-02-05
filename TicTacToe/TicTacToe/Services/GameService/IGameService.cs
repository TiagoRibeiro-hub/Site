namespace TicTacToe.Services
{
    public interface IGameService
    {
        Task<int> RegisterPlayers(RegisterPlayersRequest registerPlayers);
        Task<GameResponse> GamePlayed(GameRequest game);
    }
}
