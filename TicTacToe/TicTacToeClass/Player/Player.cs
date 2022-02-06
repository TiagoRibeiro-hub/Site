namespace TicTacToe;
#nullable disable
public class Player
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool StartFirst { get; set; }
    public Moves Moves { get; set; } = new();

}
