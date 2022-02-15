namespace Games.Data.Api;

public class GameResponse
{
    public GameResponse(int idGame, Dictionary<string, string> possibleMoves)
    {
        IdGame = idGame;
        PossibleMoves = possibleMoves;
    }

    public GameResponse(
        int idGame, string player, string gameState,
        string? gameResult, Dictionary<string, string> possibleMoves)
    {
        IdGame = idGame;
        PlayerName = player;
        GameState = gameState;
        GameResult = gameResult;
        PossibleMoves = possibleMoves;
    }

    public int IdGame { get; set; }
    public string? PlayerName { get; set; }
    public string? GameState { get; set; }
    public string? GameResult { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}
