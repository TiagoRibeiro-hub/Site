namespace TicTacToe.Data;
#nullable disable
public class ScoresTableModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PlayerName { get; set; }
    public TotalGamesVsHumanModel TotalGamesVsHuman { get; set; } = new();
    public TotalGamesVsComputerModel TotalGamesVsComputer { get; set; } = new();

}
