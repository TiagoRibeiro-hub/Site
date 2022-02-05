namespace TicTacToe.Data;
#nullable disable
public class TotalGamesVsComputerModel
{
    public int Id { get; set; }
    public TotalGamesEasyModel TotalGamesEasy { get; set; } = new();
    public TotalGamesIntermediateModel TotalGamesIntermediate { get; set; } = new();
    public TotalGamesHardModel TotalGamesHard { get; set; } = new();
    public ScoresTableModel ScoresTable { get; set; }
    public int ScoreTableId { get; set; }

}
