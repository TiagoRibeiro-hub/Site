namespace Games.Data.Extensions;

public static class GameExtension
{
    public static GameEntity SetGameEntityVsComputer(this RegisterVsComputer x)
    {
        return new GameEntity()
        {
            Player1_Name = x.Player.Name,
            Player2_Name = Computer.Name,
            IsComputer = x.IsComputer,
            Difficulty = x.Difficulty,
            StartFirst = x.StartFirst,
        };
    }

    public static GameEntity SetGameEntityVsHuman(this RegisterVsHuman x)
    {
        return new GameEntity()
        {
            Player1_Name = x.Player.Name,
            Player2_Name = x.Player2.Name,
            StartFirst = x.StartFirst,
        };
    }
}
