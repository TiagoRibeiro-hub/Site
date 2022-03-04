namespace Data.Infrastructure.Infrastructure.Api.InitializeGame;
#nullable disable
public class InitializeGameResponse
{
    public InitializeGameResponse()
    {

    }

    public InitializeGameResponse(Guid idGame, bool startGame, Dictionary<string, string> possibleMoves)
    {
        IdGame = idGame;
        StartGame = startGame;
        PossibleMoves = possibleMoves;
    }

    public Guid IdGame { get; set; }
    public bool StartGame { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}
