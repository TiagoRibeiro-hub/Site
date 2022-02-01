namespace TicTacToe.Data;
#nullable disable
public class ScoresTableModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PlayerName { get; set; }
    public int Victories { get; set; } = 0;
    public int Losses { get; set; } = 0;
    public int Ties { get; set; } = 0;
    public int TotalGames { get; set; } = 0;
    public int TotalGamesVsHuman { get; set; } = 0;
    public ICollection<TotalGamesVsComputerModel> TotalGamesVsComputer { get; set; } = new List<TotalGamesVsComputerModel>();


}
