namespace Games.Data.Game;
#nullable disable
public class Game
{
    public int Id { get; set; }
    public string Player1_Name { get; set; }
    public string Player2_Name { get; set; }
    public bool IsComputer { get; set; }
    public string Difficulty { get; set; }
    public string StartFirst { get; set; }
    public DateTime DateTimeStart { get; set; }
    public DateTime DateTimeEnd { get; set; }
}