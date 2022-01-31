namespace TicTacToe;
#nullable disable
public abstract class Player
{
    public string Name { get; set; }
    public string Symbol { get; set; }
    public List<int> ListPlayedMoves { get; set; } = new List<int>();

    public List<int> SetListPlayedMoves(List<int> listMovesPlayer, int move)
    {
        listMovesPlayer.Add(move);
        return ListPlayedMoves;
    }
}
