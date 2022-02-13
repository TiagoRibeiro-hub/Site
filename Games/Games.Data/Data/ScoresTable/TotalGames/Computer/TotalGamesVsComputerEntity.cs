namespace Games.Data.Data;
#nullable disable
public class TotalGamesVsComputerEntity
{
    public int Id { get; set; }
    public TotalGamesEasyEntity TotalGamesEasy { get; set; } = new();
    public TotalGamesIntermediateEntity TotalGamesIntermediate { get; set; } = new();
    public TotalGamesHardEntity TotalGamesHard { get; set; } = new();
    public ScoresTableEntity ScoresTable { get; set; }
    public int ScoreTableId { get; set; }

}
