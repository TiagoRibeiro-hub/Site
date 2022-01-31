namespace TicTacToe;
#nullable disable
public class Game
{
    // Request
    public Game(Human player, Computer computer, string shift)
    {
        Player = player;
        Computer = computer;
        Shift = shift;
    }

    // Response
    public Game(Human player, Computer computer, string shift, Winner winner)
    {
        Player = player;
        Computer = computer;
        Shift = shift;
        Winner = winner;
    }

    public Human Player { get; set; }
    public Computer Computer { get; set; }
    public string Shift { get; set; }
    public Winner Winner { get; set; }

}
