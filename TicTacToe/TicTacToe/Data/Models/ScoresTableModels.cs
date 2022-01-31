namespace TicTacToe.Data;

public class ScoresTableModels
{
    public int Id { get; set; }
    public string PlayerName { get; set; }
    public int Victories { get; set; }
    public int Losses { get; set; }
    public int Ties { get; set; }
}

