namespace Data.Infrastructure.Data._Entities;
#nullable disable
public class TotalGamesVsHumanEntity
{
    public TotalGamesVsHumanEntity()
    {

    }
    public TotalGamesVsHumanEntity(
        int startFirst, int startSecond, int totalGames,
        int victories, int losses, int ties,
        int scoreTableId)
    {
        StartFirst = startFirst;
        StartSecond = startSecond;
        TotalGames = totalGames;
        Victories = victories;
        Losses = losses;
        Ties = ties;
        ScoreTableId = scoreTableId;
    }

    public int Id { get; private set; }
    public int StartFirst { get; set; } = 0;
    public int StartSecond { get; set; } = 0;
    public int TotalGames { get; set; } = 0;
    public int Victories { get; set; } = 0;
    public int Losses { get; set; } = 0;
    public int Ties { get; set; } = 0;
    public ScoresTableEntity ScoresTable { get; set; }
    public int ScoreTableId { get; set; }
}