namespace Games.Data.Api;

public class GameResponse
{
    public GameResponse()
    {

    }
    public GameResponse(int idGame, string gameState, Dictionary<string, string> possibleMoves, int ticTacToeNrCol)
    {
        IdGame = idGame;
        GameState = gameState;
        TicTacToe_NrCol = ticTacToeNrCol;
        PossibleMoves = possibleMoves;
    }

    public GameResponse(
        int idGame, string player, string gameState,
        string? gameResult, Dictionary<string, string> possibleMoves, int ticTacToeNrCol)
    {
        IdGame = idGame;
        PlayerName = player;
        GameState = gameState;
        GameResult = gameResult;
        PossibleMoves = possibleMoves;
        TicTacToe_NrCol = ticTacToeNrCol;
    }

    public int IdGame { get; set; }
    public string? PlayerName { get; set; }
    public string GameState { get; set; }
    public string? GameResult { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
    public int TicTacToe_NrCol { get; set; }
}
