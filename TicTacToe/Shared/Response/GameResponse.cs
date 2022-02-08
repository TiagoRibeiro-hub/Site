namespace TicTacToe;
#nullable disable
public class GameResponse
{
    public int IdGame { get; set; }
    public bool HaveWinner { get; set; }
    public string WinnerName { get; set; }
    public bool GameFinished { get; set; } = false;
    public string State { get; set; }
    public string Difficulty { get; set; }
    public List<int> PossibleMoves { get; set; }
}
