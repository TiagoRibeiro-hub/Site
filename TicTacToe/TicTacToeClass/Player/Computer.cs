namespace TicTacToe;
#nullable disable
public class Computer : Player
{
    public string Difficulty { get; set; }
    public bool Active { get; set; } = false;
    public bool Easy { get; set; } = false;
    public bool Intermediate { get; set; } = false;
    public bool Hard { get; set; } = false;
}
