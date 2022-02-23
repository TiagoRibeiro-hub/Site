namespace Games.Data.Extensions;

public static class InitializeGameExtensions
{
    public static GameEntity SetGameEntity(this InitializeGameRequest x)
    {
        bool isComputer = false;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        string difficulty = null, playerName_2;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        if (x.VsComputer.IsComputer)
        {
            isComputer = true;
            playerName_2 = Computer.Name;
            difficulty = x.VsComputer.Difficulty;
        }
        else
        {
            playerName_2 = x.VsHuman.PlayerName_2;
        }

        return new GameEntity
        (
            player1_Name: x.PlayerName_1,
            player2_Name: playerName_2,
            isComputer: isComputer,
            difficulty: difficulty,
            startFirst: x.StartFirst
        );
    }
    public static ScoresTableEntity SetScoreTablePlayerName(this InitializeGameRequest x, string playerName)
    {
        return new ScoresTableEntity
        (
            playerName: playerName
        );
    }

    public static TotalGamesUpdate SetTotalGamesUpdate(this InitializeGameRequest x, string playerName, int scoreTableId)
    {
        return new TotalGamesUpdate
            (
                playerName: playerName,
                startFirst: x.StartFirst,
                scoreTableId: scoreTableId,
                vsComputer: x.VsComputer
            );
    }
}
