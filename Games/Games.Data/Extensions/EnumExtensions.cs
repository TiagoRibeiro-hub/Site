namespace Games.Data.Extensions;

public static class EnumExtensions
{
    public static string GameStateToString(this GameState x)
    {
        return x.ToString().ToUpper();
    }
    public static string GameResultToString(this GameResult x)
    {
        return x.ToString().ToUpper();
    }
    public static string GameTypeToString(this GameType x)
    {
        return x.ToString().ToUpper();
    }
    public static bool GetGameType(this GameType x, string gameType)
    {
        if(x.GameTypeToString() == gameType.ToLower())
        {
            return true;
        }
        return false;
    }
}