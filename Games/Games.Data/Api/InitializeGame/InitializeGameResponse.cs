namespace Games.Data.Api;
#nullable disable
public class InitializeGameResponse
{
    public InitializeGameResponse()
    {

    }
    public InitializeGameResponse(int idGame, bool startGame, Dictionary<string, string> possibleMoves)
    {
        IdGame = idGame;
        StartGame = startGame;
        PossibleMoves = possibleMoves;
    }

    public int IdGame { get; set; }
    public bool StartGame { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}

