namespace TicTacToe;
#nullable disable
public class Computer : Player
{
    public string Email { get; private set; } = "computer@email.com";
    public bool Easy { get; set; } = false;
    public bool Intermediate { get; set; } = false;
    public bool Hard { get; set; } = false;
}
