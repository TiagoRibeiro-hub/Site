namespace TicTacToe;
#nullable disable
public class Moves
{
    public string PlayerName { get; set; }
    public string MoveTo { get; set; } = "0";
    public string MoveFrom { get; set; }
    public int MoveNumber { get; set; } = 0;
    public int GameId { get; set; }
    public HashSet<int> ListPlayedMoves { get; set; }
}
