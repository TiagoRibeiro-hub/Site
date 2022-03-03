namespace _00.Data.Game;
#nullable disable
public class GameOptions
{
    public string GameTypeName { get; set; }
    public GameTypeOptions GetGameTypeOptions { get; set; }
}

public class GameTypeOptions
{
    public int TicTacToeNumberColumns { get; set; }
}