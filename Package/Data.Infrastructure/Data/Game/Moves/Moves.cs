namespace Data.Infrastructure.Data.Game.Moves;
#nullable disable
public class Moves
{
    public int GameId { get; set; }
    public string PlayerName { get; set; }
    public string MoveTo { get; set; }
    public string MoveFrom { get; set; }
    public int MoveNumber { get; set; }
    public Dictionary<string, string> ListPlayedMoves { get; set; } = new();
}