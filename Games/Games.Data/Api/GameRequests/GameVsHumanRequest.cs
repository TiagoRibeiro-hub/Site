namespace Games.Data.Api;

public class GameVsHumanRequest : GameRequest
{
    public GameVsHumanRequest()
    {

    }
    public GameVsHumanRequest(int idGame, bool isComputer, Player player, string moveTo, Dictionary<string, string> possibleMoves) 
        : base(idGame, isComputer, possibleMoves)
    {
        IdGame = idGame;
        IsComputer = isComputer;
        Player = player;
        MoveTo = moveTo;
        PossibleMoves = possibleMoves;
    }

    public Player Player { get; set; }
    public string MoveTo { get; set; }
    
}
