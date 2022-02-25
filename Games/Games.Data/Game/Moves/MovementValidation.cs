namespace Games.Data.Game;

public class MovementValidation
{
    public MovementValidation(GameOptions getGameType, Movement getMovement, Dictionary<string, string> getPossibleMoves)
    {
        GetGameType = getGameType;
        GetMovement = getMovement;
        GetPossibleMoves = getPossibleMoves;
    }

    public MovementValidation(PlayRequest playRequest)
    {
        GetGameType = playRequest.GetGameType;
        GetMovement = playRequest.Movements;
        GetPossibleMoves = playRequest.PossibleMoves;
    }
    public GameOptions GetGameType { get; set; }
    public Movement GetMovement { get; set; }
    public Dictionary<string, string> GetPossibleMoves { get; set; }
}