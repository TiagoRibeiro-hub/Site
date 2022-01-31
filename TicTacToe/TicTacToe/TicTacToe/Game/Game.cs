namespace TicTacToe;
#nullable disable
public class Game
{
    // Request
    public Game(Human human, Computer computer, string shift)
    {
        Human = human;
        Computer = computer;
        Shift = shift;
    }

    // Response
    public Game(Human human, Computer computer, string shift, Winner winner)
    {
        Human = human;
        Computer = computer;
        Shift = shift;
        Winner = winner;
    }

    public Human Human { get; set; }
    public Computer Computer { get; set; }
    public string Shift { get; set; }
    public Winner Winner { get; set; }

}
