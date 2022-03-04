using Data.Infrastructure.Data.Game;
using Data.Infrastructure.Data.Game.Moves;
using Data.Infrastructure.Data.Game.Player;

namespace Data.Infrastructure.Infrastructure.Api.PlayGame;
#nullable disable
public abstract class PlayRequest
{
    public GameOptions GetGameType { get; set; }
    public int IdGame { get; set; }
    public VsComputer VsComputer { get; set; }
    public string PlayerName { get; set; }
    public Movement Movements { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}