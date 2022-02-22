namespace Games.Data.Extensions;

public static class EnumExtensions
{
    // Game Type
    public static string GameTypeToStringUpper(this GameType x)
    {
        return x.ToString().ToUpper();
    }
    public static bool GetGameType(this GameType x, string gameType)
    {
        if(x.GameTypeToStringUpper() == gameType.ToUpper())
        {
            return true;
        }
        return false;
    }

    // Game State
    public static string GameStateToStringUpper(this GameState x)
    {
        return x.ToString().ToUpper();
    }

    // GameResult
    public static string GameResultToStringUpper(this GameResult x)
    {
        return x.ToString().ToUpper();
    }

    // Difficulty
    public static string DifficultyToStringUpper(this Difficulty x)
    {
        return x.ToString().ToUpper();
    }
    public static bool GetDifficulty(this Difficulty x, string difficulty)
    {
        if (x.DifficultyToStringUpper() == difficulty.ToUpper())
        {
            return true;
        }
        return false;
    }
}