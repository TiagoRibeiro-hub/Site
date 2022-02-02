namespace TicTacToe;
#nullable disable
public class Request
{
    public string Player1 { get; set; }
    public string Player2 { get; set; }

}

public class RegisterPlayersRequest : Request
{
    public string Player1_Email { get; set; }
    public string Player2_Email { get; set; }
    public bool ComputerIsActive { get; set; }
    public string Difficulty { get; set; }
    public string FirstPlayerName { get; set; }
}

public class GameRequest : Request
{
    public string Shift { get; set; }
    public HashSet<int> Player1Moves { get; set; }
    public HashSet<int> Player2Moves { get; set; }
    public bool HaveWinner { get; set; }
    public string Winner { get; set; }
}

