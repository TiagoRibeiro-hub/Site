namespace _00.Data._Entities;

public class MovesEntity
{
    public MovesEntity(
        string playerName, string moveTo, string moveFrom,
        int moveNumber, int gameId)
    {
        PlayerName = playerName;
        MoveTo = moveTo;
        MoveFrom = moveFrom;
        MoveNumber = moveNumber;
        GameId = gameId;
    }

    public int Id { get; private set; }
    public string PlayerName { get; set; }
    public string MoveTo { get; set; }
    public string MoveFrom { get; set; }
    public int MoveNumber { get; set; }
    public DateTime DateTimeMove { get; set; } = DateTime.Now.ToUniversalTime();
    public GameEntity Game { get; set; }
    public int GameId { get; set; }

}