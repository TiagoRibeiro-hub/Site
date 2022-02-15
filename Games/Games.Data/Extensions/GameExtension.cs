using Games.Infrastructure.Enums;

namespace Games.Data.Extensions;

public static class GameExtension
{
    public static GameEntity SetGameEntityVsComputer(this RegisterVsComputer x)
    {
        StartFirst startFirst = new(x.Player.Turn, x.Player.Name, Computer.Name);
        return new GameEntity()
        {
            Player1_Name = x.Player.Name,
            Player2_Name = Computer.Name,
            IsComputer = x.IsComputer,
            Difficulty = x.Difficulty,
            StartFirst = startFirst.GetStartFirst()
        };
    }
    public static GameEntity SetGameEntityVsHuman(this RegisterVsHuman x)
    {
        StartFirst startFirst = new(x.Player.Turn, x.Player.Name, x.Player2.Name);
        return new GameEntity()
        {
            Player1_Name = x.Player.Name,
            Player2_Name = x.Player2.Name,
            StartFirst = startFirst.GetStartFirst()
        };
    }
}
