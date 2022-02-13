namespace Games.Data.Data;
#nullable disable
public class ScoresTableEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PlayerName { get; set; }
    public TotalGamesVsHumanEntity TotalGamesVsHuman { get; set; } = new();
    public TotalGamesVsComputerEntity TotalGamesVsComputer { get; set; } = new();

}
