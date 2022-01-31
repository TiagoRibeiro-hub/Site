namespace TicTacToe;
#nullable disable
public class Computer : Player
{
    public bool Active { get; set; } = false;
    public bool Easy { get; set; }
    public bool Intermediate { get; set; }
    public bool Hard { get; set; }
    public bool Difficulty { get; internal set; }
}
