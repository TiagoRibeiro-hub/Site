namespace TicTacToe;
#nullable disable
public class GameRequest : Request
{
    public int IdGame { get; set; }
    public string PlayerName { get; set; }
    public Dictionary<int, int> PlayerMoves { get; set; }
}

