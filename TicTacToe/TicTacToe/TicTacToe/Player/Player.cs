namespace TicTacToe;
#nullable disable
public abstract class Player
{
    public string Name { get; set; }
    public HashSet<int> ListPlayedMoves { get; set; }

    public HashSet<int> SetListPlayedMoves(HashSet<int> listMovesPlayer, int move)
    {
        listMovesPlayer.Add(move);
        return ListPlayedMoves;
    }
}
