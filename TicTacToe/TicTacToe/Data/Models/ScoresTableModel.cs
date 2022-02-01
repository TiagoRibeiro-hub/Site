namespace TicTacToe.Data;
#nullable disable
public class ScoresTableModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PlayerName { get; set; }
    public int Victories { get; set; }
    public int Losses { get; set; }
    public int Ties { get; set; }
    public int TotalGames { get; set; }
    public int TotalGamesVsHuman { get; set; }
    public ICollection<TotalGamesVsComputerModel> TotalGamesVsComputer { get; set; } = new List<TotalGamesVsComputerModel>();
}
