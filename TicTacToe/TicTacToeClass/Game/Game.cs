namespace TicTacToe;
#nullable disable
public class Game
{
    // Request
    public Game(Human human, Computer computer, string shift, HashSet<int> possibleMoves)
    {
        Human = human;
        Computer = computer;
        Shift = shift;
        PossibleMoves = possibleMoves;
    }

    // Response
    public Game(Human human, Computer computer, Winner winner, string shift, HashSet<int> possibleMoves)
    {
        Human = human;
        Computer = computer;
        Winner = winner;
        Shift = shift;
        PossibleMoves = possibleMoves;
    }

    public Human Human { get; set; }
    public Computer Computer { get; set; }
    public Winner Winner { get; set; }
    public string Shift { get; set; }
    public HashSet<int> PossibleMoves { get; set; }

}
