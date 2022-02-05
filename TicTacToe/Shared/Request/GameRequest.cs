namespace TicTacToe;
#nullable disable
public class GameRequest 
{
    public int IdGame { get; set; }
    public string PlayerName { get; set; }
    public bool IsComputer { get; set; }
    public bool IsFirstMove { get; set; }
    public int MovePlayed { get; set; }
}

