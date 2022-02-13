namespace Games.Data.Data;
#nullable disable
public class MovesEntity
{
    public int Id { get; set; }
    public string PlayerName { get; set; }
    public string MoveTo { get; set; } = "0";
    public string MoveFrom { get; set; }
    public int MoveNumber { get; set; }= 0;
    public DateTime DateTimeMove { get; set; } = DateTime.Now.ToUniversalTime();
    public GameEntity Game { get; set; }
    public int GameId { get; set; }
    
}

