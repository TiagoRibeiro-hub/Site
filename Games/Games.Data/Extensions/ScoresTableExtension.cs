namespace Games.Data.Extensions;

public static class ScoresTableExtension
{
    public static ScoresTableEntity SetScoreTableVsComputer(this RegisterVsComputer x)
    {
        return new ScoresTableEntity()
        {
            Email = x.Player.Email,
            PlayerName = x.Player.Name,
        };
    }

    public static HashSet<ScoresTableEntity> SetScoreTableVsHuman(this RegisterVsHuman x)
    {
        HashSet<ScoresTableEntity> scoresTableList = new();
        scoresTableList.Add(new ScoresTableEntity()
        {
            Email = x.Player.Email,
            PlayerName = x.Player.Name,
        });
        scoresTableList.Add(new ScoresTableEntity()
        {
            Email = x.Player2.Email,
            PlayerName = x.Player2.Name,
        });
        return scoresTableList;
    }
}
