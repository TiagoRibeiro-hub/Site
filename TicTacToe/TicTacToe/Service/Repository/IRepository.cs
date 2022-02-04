namespace TicTacToe.Service;
public interface IRepository
{
    Task<int> RegisterPlayers(RegisterPlayersRequest registerPlayers);
    Task<GameResponse> GamePlayed(GameRequest game);
}

