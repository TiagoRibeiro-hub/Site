namespace TicTacToe;
#nullable disable
public class Winner : Ties
{
    public int GameId { get; set; }
    public string WinnerName { get; set; }
    public string LoserName { get; set; }
    public bool HaveWinner { get; set; }
    public bool GameFinished { get; set; } = false;
    public string State { get; set; }

}
