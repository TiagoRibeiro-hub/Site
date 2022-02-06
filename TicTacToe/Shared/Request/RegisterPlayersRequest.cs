namespace TicTacToe;
#nullable disable
public class RegisterPlayersRequest : Request
{
    public List<PlayerRequest> ListPlayers { get; set; }
    public bool Easy { get; set; } = false;
    public bool Intermediate { get; set; } = false;
    public bool Hard { get; set; } = false;
}

