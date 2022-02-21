

namespace Games.Data.Extensions;

public static class ScoresTableExtensions
{
    public static ScoresTableEntity SetScoreTableVsComputer(this InitializeGameRequest x)
    {
        return new ScoresTableEntity
        (
            email: x.PlayerEmail_1,
            playerName: x.PlayerName_1
        );
    }
    //public static HashSet<ScoresTableEntity> SetScoreTableVsHuman(this RegisterVsHuman x)
    //{
    //    HashSet<ScoresTableEntity> scoresTableList = new();
    //    scoresTableList.Add(new ScoresTableEntity
    //    (
    //        email: x.Player.Email,
    //        playerName: x.Player.Name
    //    ));
    //    scoresTableList.Add(new ScoresTableEntity
    //    (
    //        email: x.Player2.Email,
    //        playerName: x.Player2.Name
    //    ));
    //    return scoresTableList;
    //}
    public static ScoresTableEntity SetScoreTableTotalGames(this ScoresTableEntity scoreTable, GameEntity game)
    {
        if (game.IsComputer)
        {
            if (game.Difficulty.ToLower() == Difficulty.Easy.ToString().ToLower())
            {
                _ = game.StartFirst == scoreTable.PlayerName ? scoreTable.TotalGamesVsComputer.TotalGamesEasy.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesEasy.StartSecond += 1;
                scoreTable.TotalGamesVsComputer.TotalGamesEasy.TotalGames += 1;

            }
            if (game.Difficulty.ToLower() == Difficulty.Intermediate.ToString().ToLower())
            {
                _ = game.StartFirst == scoreTable.PlayerName ? scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.StartSecond += 1;
                scoreTable.TotalGamesVsComputer.TotalGamesIntermediate.TotalGames += 1;
            }
            if (game.Difficulty.ToLower() == Difficulty.Hard.ToString().ToLower())
            {
                _ = game.StartFirst == scoreTable.PlayerName ? scoreTable.TotalGamesVsComputer.TotalGamesHard.StartFirst += 1 : scoreTable.TotalGamesVsComputer.TotalGamesHard.StartSecond += 1;
                scoreTable.TotalGamesVsComputer.TotalGamesHard.TotalGames += 1;
            }
        }
        else
        {
            _ = game.StartFirst == scoreTable.PlayerName ? scoreTable.TotalGamesVsHuman.StartFirst += 1 : scoreTable.TotalGamesVsHuman.StartSecond += 1;
            scoreTable.TotalGamesVsHuman.TotalGames += 1;
        }

        return scoreTable;
    }

}
