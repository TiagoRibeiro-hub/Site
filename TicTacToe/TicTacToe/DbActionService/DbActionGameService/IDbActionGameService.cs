using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public interface IDbActionGameService
{
    Task<bool> IsRegisterByPlayerName(string playerName);
    Task<int> GetScoresTableIdByPlayerNameAsync(string playerName);
    Task<ScoresTableModel> GetScoresTableByPlayerNameAsync(string playerName);

    Task InsertScoresTableAsync(ScoresTableModel scoreTable);
    Task<int> InsertInitializeGame(GameModel game, HashSet<Moves> listPlayerMovesInit);
    Task RegisterMove(Game game);
}

