namespace Data.Infrastructure.Data.Game.Moves;

public class MovementValidation
{
    public MovementValidation(GameOptions getGameType, Movement getMovement, Dictionary<string, string> getPossibleMoves)
    {
        GetGameType = getGameType;
        GetMovement = getMovement;
        GetPossibleMoves = getPossibleMoves;
    }

    public GameOptions GetGameType { get; set; }
    public Movement GetMovement { get; set; }
    public Dictionary<string, string> GetPossibleMoves { get; set; }
}