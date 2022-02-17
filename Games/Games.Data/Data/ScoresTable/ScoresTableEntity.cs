namespace Games.Data.Data;
#nullable disable
public class ScoresTableEntity
{
    public ScoresTableEntity(string email, string playerName)
    {
        Email = email;
        PlayerName = playerName;
    }

    public int Id { get; private set; }
    public string Email { get; set; }
    public string PlayerName { get; set; }
    public TotalGamesVsHumanEntity TotalGamesVsHuman { get; set; } = new();
    public TotalGamesVsComputerEntity TotalGamesVsComputer { get; set; } = new();

}
