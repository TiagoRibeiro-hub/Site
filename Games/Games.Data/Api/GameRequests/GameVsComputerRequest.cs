namespace Games.Data.Api;
public class GameVsComputerRequest : GameRequest
{
    public GameVsComputerRequest(int idGame, bool isComputer, string difficulty, Dictionary<string, string> possibleMoves)
        : base(idGame, isComputer, possibleMoves)
    {
        IdGame = idGame;
        IsComputer = isComputer;
        Difficulty = difficulty;
        PossibleMoves = possibleMoves;
    }


    public string Difficulty { get; set; }

}
