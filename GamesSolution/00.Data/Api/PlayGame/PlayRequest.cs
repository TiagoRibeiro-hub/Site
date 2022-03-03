using _00.Data.Game;
using _00.Data.Game.Moves;
using _00.Data.Game.Player;

namespace _00.Data.Api.PlayGame;

public abstract class PlayRequest
{
    public GameOptions GetGameType { get; set; }
    public int IdGame { get; set; }
    public VsComputer VsComputer { get; set; }
    public string PlayerName { get; set; }
    public Movement Movements { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}