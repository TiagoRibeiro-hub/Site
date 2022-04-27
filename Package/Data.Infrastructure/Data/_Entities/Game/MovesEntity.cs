namespace Data.Infrastructure.Data._Entities;
#nullable disable
public class MovesEntity
{
    public MovesEntity(Guid gameId, string playerName, string moveTo, string moveFrom, int moveNumber)
    {
        _GameId = gameId;
        PlayerName = playerName;
        MoveTo = moveTo;
        MoveFrom = moveFrom;
        MoveNumber = moveNumber;
    }

    public int Id { get; private set; }
    public Guid _GameId { get; set; }
    public string PlayerName { get; set; }
    public string MoveTo { get; set; }
    public string MoveFrom { get; set; }
    public int MoveNumber { get; set; }
    public DateTime DateTimeMove { get; set; } = DateTime.Now.ToUniversalTime();
    public GameEntity Game { get; set; }
    public int GameId { get; set; }

}