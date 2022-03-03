using _00.Data.Game;
using _00.Data.Game.Player;

namespace _00.Data.Api.PlayGame;

public class PlayResponse
{
    public PlayResponse()
    {

    }

    public PlayResponse(GameOptions getGameType,
        int idGame, string? playerName, string? gameState, string? gameResult,
        VsComputer vsComputer, Dictionary<string, string>? possibleMoves)
    {
        GetGameType = getGameType;
        IdGame = idGame;
        PlayerName = playerName;
        GameState = gameState;
        GameResult = gameResult;
        VsComputer = vsComputer;
        PossibleMoves = possibleMoves;
    }

    public GameOptions GetGameType { get; set; }
    public int IdGame { get; set; }
    public string? PlayerName { get; set; }
    public string? GameState { get; set; }
    public string? GameResult { get; set; }
    public VsComputer VsComputer { get; set; }
    public Dictionary<string, string>? PossibleMoves { get; set; }
}
