namespace TicTacToe;
#nullable disable
public abstract class Player
{
    public string Name { get; set; }
    public List<int> ListPlayedMoves { get; set; }

    public List<int> SetListPlayedMoves(List<int> listMovesPlayer, int move)
    {
        listMovesPlayer.Add(move);
        return ListPlayedMoves;
    }
}
