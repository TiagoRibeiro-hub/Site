using Data.Infrastructure.Data.Game;
using Data.Infrastructure.Data.Game.Player;

namespace Data.Infrastructure.Infrastructure.Api.PlayGame;
#nullable disable
public class PlayResponse
{
    public PlayResponse()
    {

    }

    public PlayResponse(Guid idGame, string playerName, 
        string gameState, string gameResult, 
        VsComputer vsComputer, Dictionary<string, string> possibleMoves)
    {
        IdGame = idGame;
        PlayerName = playerName;
        GameState = gameState;
        GameResult = gameResult;
        VsComputer = vsComputer;
        PossibleMoves = possibleMoves;
    }

    public Guid IdGame { get; set; }
    public string PlayerName { get; set; }
    public string GameState { get; set; }
    public string GameResult { get; set; }
    public VsComputer VsComputer { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}
