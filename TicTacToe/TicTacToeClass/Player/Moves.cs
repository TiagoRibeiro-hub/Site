namespace TicTacToe;
#nullable disable
public class Moves
{
    public string PlayerName { get; set; }
    public int Move { get; set; } = 0;
    public int MoveNumber { get; set; } = 0;
    public int GameId { get; set; }
    public HashSet<int> ListPlayedMoves { get; set; }
}
