namespace TicTacToe.Data;
#nullable disable
public class TotalGamesVsComputerModel
{
    public int Id { get; set; }
    public int TotalGames { get; set; } = 0;
    public int TotalGamesEasy { get; set; } = 0;
    public int TotalGamesIntermediate { get; set; } = 0;
    public int TotalGamesHard { get; set; } = 0;
    public ScoresTableModel ScoresTable { get; set; }
    public int ScoreTableId { get; set; }

}