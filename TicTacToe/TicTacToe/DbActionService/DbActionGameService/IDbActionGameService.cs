using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public interface IDbActionGameService
{
    Task<(string, string)> GetPlayersGameByGameIdAsync(int gameId);
    Task<int> InsertInitializeGame(GameModel game, HashSet<Moves> listPlayerMovesInit);
    Task RegisterMove(Game game);
}

