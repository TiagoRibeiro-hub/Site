namespace TicTacToe;
#nullable disable
public class RegisterPlayersRequest : Request
{
    public PlayerRequest Player1 { get; set; }
    public PlayerRequest Player2 { get; set; }
    public string Difficulty { get; set; }
}

public class PlayerRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
}

