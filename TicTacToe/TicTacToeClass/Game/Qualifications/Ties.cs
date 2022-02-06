namespace TicTacToe;

public class Ties
{
    public string PlayerName1 { get; set; }
    public string PlayerName2 { get; set; }
    public GameState GameState { get; private set; } = GameState.Tie;
}
