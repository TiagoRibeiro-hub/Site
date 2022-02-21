namespace Games.Data.Extensions;

public static class GameExtensions
{
    public static GameEntity SetGameEntity(this InitializeGameRequest x)
    {
        bool isComputer = false;
        string difficulty = null, playerName_2;

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
}
