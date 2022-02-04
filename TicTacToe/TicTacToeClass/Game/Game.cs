namespace TicTacToe;
#nullable disable
public class Game
{
    public int GameId { get; set; }
    public Player Player { get; set; } = new();
    public string Shift { get; set; }

}
