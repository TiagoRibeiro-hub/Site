namespace _00.Data._Entities;
#nullable disable
public class GameEntity
{
    public GameEntity(
        string player1_Name, string player2_Name, bool isComputer,
        string difficulty, string startFirst)
    {
        Player1_Name = player1_Name;
        Player2_Name = player2_Name;
        IsComputer = isComputer;
        Difficulty = difficulty;
        StartFirst = startFirst;
    }

    public GameEntity(int id, DateTime dateTimeEnd)
    {
        Id = id;
        DateTimeEnd = dateTimeEnd;
    }

    public int Id { get; private set; }
    public string Player1_Name { get; set; }
    public string Player2_Name { get; set; }
    public bool IsComputer { get; set; } = false;
    public string Difficulty { get; set; } = null;
    public string StartFirst { get; set; }
    public DateTime DateTimeStart { get; private set; } = DateTime.Now.ToUniversalTime();
    public DateTime DateTimeEnd { get; set; }
    public ICollection<MovesEntity> Moves { get; set; }
}
