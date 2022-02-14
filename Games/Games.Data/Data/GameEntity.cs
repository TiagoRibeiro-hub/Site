namespace Games.Data.Data;
#nullable disable
public class GameEntity
{
    public int Id { get; set; }
    public string Player1_Name { get; set; }
    public string Player2_Name { get; set; }
    public bool IsComputer { get; set; } = false;
    public string Difficulty { get; set; } = null;
    public string StartFirst { get; set; }
    public DateTime DateTimeStart { get; private set; } = DateTime.Now.ToUniversalTime();
    public DateTime DateTimeEnd { get; set; }
    public ICollection<MovesEntity> Moves { get; set; }
}

