namespace Games.Data.Api;

public class GameRequest
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