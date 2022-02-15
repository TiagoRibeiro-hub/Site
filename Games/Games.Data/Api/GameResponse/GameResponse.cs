namespace Games.Infrastructure.Api;

public class GameResponse
{
    public GameResponse(int idGame)
    {
        IdGame = idGame;
    }

    public GameResponse(
        int idGame, string player, string gameState,
        string? gameResult, HashSet<int> possibleMoves)
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
    public HashSet<int>? PossibleMoves { get; set; }
}
