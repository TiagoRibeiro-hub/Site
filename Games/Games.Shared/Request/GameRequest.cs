namespace Games.Shared;
#nullable disable
public class GameRequest : Request
{
    public int IdGame { get; set; }
    public string PlayerName { get; set; }
    public string MoveTo { get; set; }
    public string Difficulty { get; set; }
    public List<int> PossibleMoves { get; set; }
}
