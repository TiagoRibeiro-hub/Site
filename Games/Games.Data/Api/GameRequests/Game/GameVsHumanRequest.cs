namespace Games.Data.Api;
#nullable disable
public class GameVsHumanRequest : GameRequest
{
    public GameVsHumanRequest()
    {

    }
    public GameVsHumanRequest(int idGame, bool isComputer, Player player, string moveTo, string moveFrom, Dictionary<string, string> possibleMoves) 
        : base(idGame, isComputer, possibleMoves)
    {
        IdGame = idGame;
        IsComputer = isComputer;
        Player = player;
        MoveTo = moveTo;
        MoveFrom = moveFrom;
        PossibleMoves = possibleMoves;
    }

    public Player Player { get; set; }
    public string MoveTo { get; set; }
    public string MoveFrom { get; set; }

}
