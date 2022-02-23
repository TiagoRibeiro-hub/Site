

namespace Games.Data.Extensions;

public static class ScoresTableExtensions
{


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
