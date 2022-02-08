namespace TicTacToe;
#nullable disable
public class GameComputerRequest : Request
{
    public int IdGame { get; set; }
    public string Difficulty { get; set; }
    public List<int> PossibleMoves { get; set; }
}