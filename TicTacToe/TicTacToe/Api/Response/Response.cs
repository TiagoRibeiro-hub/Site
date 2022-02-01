namespace TicTacToe;
#nullable disable
public class Response
{
    public string IdGame { get; set; }
    public string Player { get; set; }
    public Shift Shift { get; set; }
    public HashSet<int> Player1Moves { get; set; }
    public HashSet<int> Player2Moves { get; set; }
    public string Difficulty { get; set; }

}

public class WinnerResponse : Response
{
    public bool HaveWinner { get; set; }
    public string Winner { get; set; }
}
