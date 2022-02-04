namespace TicTacToe;
#nullable disable
public class Response
{
    public string Message { get; set; } = "Everthing Ok";
    public bool IsSuccess { get; set; } = true;

}

public class GameResponse : Response
{
    public int IdGame { get; set; }
    public string Player { get; set; }
    public string Shift { get; set; }
    public HashSet<int> Player1Moves { get; set; }
    public HashSet<int> Player2Moves { get; set; }
    public string Difficulty { get; set; }

}
public class WinnerResponse : Response
{
    public bool HaveWinner { get; set; }
    public string Winner { get; set; }
}
