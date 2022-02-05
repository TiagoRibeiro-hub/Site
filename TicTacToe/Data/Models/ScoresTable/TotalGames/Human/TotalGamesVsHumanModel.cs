namespace TicTacToe.Data;
#nullable disable
public class TotalGamesVsHumanModel
{
    public int Id { get; set; }
    public int StartFirst { get; set; } = 0;
    public int StartSecond { get; set; } = 0;
    public int TotalGames { get; set; } = 0;
    public int Victories { get; set; } = 0;
    public int Losses { get; set; } = 0;
    public int Ties { get; set; } = 0;
    public ScoresTableModel ScoresTable { get; set; }
    public int ScoreTableId { get; set; }
}