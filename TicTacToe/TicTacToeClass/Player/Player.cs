namespace TicTacToe;
#nullable disable
public class Player
{
    public string Name { get; set; }
    public bool StartFirst { get; set; }
    public bool IsComputer { get; set; } = false;
    public string Difficulty { get; set; }   
    public Moves Moves { get; set; } = new();

}
