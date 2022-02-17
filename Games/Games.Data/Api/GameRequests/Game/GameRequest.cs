namespace Games.Data.Api;
#nullable disable
public class GameRequest : Request
{
    public GameRequest()
    {

    }
    public GameRequest(int idGame, bool isComputer, Dictionary<string, string> possibleMoves)
    {
        IdGame = idGame;
        IsComputer = isComputer;
        PossibleMoves = possibleMoves;
    }
    public int IdGame { get; set; }
    public bool IsComputer { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}
