namespace TicTacToe;

public class Moves
{
    public int Move { get; set; }
    public bool IsfirstMove { get; set; }
    public HashSet<int> ListPlayedMoves { get; set; }
}