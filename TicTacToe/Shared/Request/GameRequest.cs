namespace TicTacToe;
#nullable disable
public class GameRequest : Request
{
    public int IdGame { get; set; }
    public string PlayerName { get; set; }
    public bool IsFirstMove { get; set; }
    public int MovePlayed { get; set; }
}
