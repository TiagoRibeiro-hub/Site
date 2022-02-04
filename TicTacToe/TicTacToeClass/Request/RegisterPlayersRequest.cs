namespace TicTacToe;
#nullable disable
public class RegisterPlayersRequest : Request
{
    public string Player1 { get; set; }
    public string Player2 { get; set; }
    public string Player1_Email { get; set; }
    public string Player2_Email { get; set; }
    public string Difficulty { get; set; }
}

