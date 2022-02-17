namespace Games.Data.Api;
#nullable disable
public class GameRequest : Request
{
    public int IdGame { get; set; }
    public bool IsComputer { get; set; }
    public int MoveNumber { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}
