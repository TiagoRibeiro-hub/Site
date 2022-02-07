namespace TicTacToe;
#nullable disable
public class Game
{
    public int GameId { get; set; }
    public Player Player { get; set; } = new();
    public bool IsComputer { get; set; }
    public bool Easy { get; set; } = false;
    public bool Intermediate { get; set; } = false;
    public bool Hard { get; set; } = false;
    public List<int> PossibleMoves { get; set; }
}
