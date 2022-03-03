namespace _00.Data.Game.TotalGames;
public class TotalGamesQualifications
{
    public TotalGamesQualifications(int scoreTableId, string playerName, int victories, int losses, int ties)
    {
        ScoreTableId = scoreTableId;
        PlayerName = playerName;
        Victories = victories;
        Losses = losses;
        Ties = ties;
    }

    public int ScoreTableId { get; set; }
    public string PlayerName { get; set; }
    public int Victories { get; set; }
    public int Losses { get; set; }
    public int Ties { get; set; }
}
