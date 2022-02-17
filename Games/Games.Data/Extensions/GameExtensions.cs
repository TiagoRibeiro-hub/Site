namespace Games.Data.Extensions;

public static class GameExtensions
{
    public static GameEntity SetGameEntityVsComputer(this RegisterVsComputer x)
    {
        StartFirst startFirst = new(x.Player.Turn, x.Player.Name, Computer.Name);
        return new GameEntity
        (
            player1_Name: x.Player.Name,
            player2_Name: Computer.Name,
            isComputer: x.IsComputer,
            difficulty: x.Difficulty,
            startFirst: startFirst.GetStartFirst()
        );
    }
    public static GameEntity SetGameEntityVsHuman(this RegisterVsHuman x)
    {
        StartFirst startFirst = new(x.Player.Turn, x.Player.Name, x.Player2.Name);
        return new GameEntity
        (
            player1_Name: x.Player.Name,
            player2_Name: x.Player2.Name,
            isComputer: false,
            difficulty: null,
            startFirst: startFirst.GetStartFirst()
        );
    }

}
