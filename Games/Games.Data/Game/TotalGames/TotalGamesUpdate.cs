namespace Games.Data.Game;

public class TotalGamesUpdate
{
    public TotalGamesUpdate(string playerName, string startFirst, int scoreTableId, VsComputer vsComputer)
    {
        PlayerName = playerName;
        StartFirst = startFirst;
        ScoreTableId = scoreTableId;
        VsComputer = vsComputer;
    }

    public string PlayerName { get; set; }
    public string StartFirst { get; set; }
    public int ScoreTableId { get; set; }
    public VsComputer VsComputer { get; set; }

}