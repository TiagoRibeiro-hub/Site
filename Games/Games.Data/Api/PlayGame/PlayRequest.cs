namespace Games.Data.Api;
#nullable disable
public abstract class PlayRequest
{
    public GameOptions GameType { get; set; }
    public int IdGame { get; set; }
    public VsComputer VsComputer { get; set; }
    public string PlayerName { get; set; }
    public int MoveNumber { get; set; }
    public string MoveTo { get; set; }
    public string MoveFrom { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}
