using _00.Data.Enums;

namespace _00.Data.Extensions;
public static class EnumsExtensions
{
    // GameType
    #region GameType
    public static string GameTypeToStringUpper(this GameType x)
    {
        return x.ToString().ToUpper();
    }
    public static bool GetGameType(this GameType x, string gameType)
    {
        if (x.GameTypeToStringUpper() == gameType.ToUpper())
        {
            return true;
        }
        return false;
    }
    public static HashSet<string> GetGameTypeList()
    {
        HashSet<string> result = new();
        result.Add(GameType.TicTacToe.GameTypeToStringUpper());
        result.Add(GameType.Chess.GameTypeToStringUpper());
        return result;
    }
    #endregion

    // GameState
    #region GameState
    public static string GameStateToStringUpper(this GameState x)
    {
        return x.ToString().ToUpper();
    }
    #endregion

    // GameResult
    #region GameResult
    public static string GameResultToStringUpper(this GameResult x)
    {
        return x.ToString().ToUpper();
    }
    #endregion

    // Difficulty
    #region Difficulty
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
    public static HashSet<string> GetDifficultyList()
    {
        HashSet<string> result = new();
        result.Add(Difficulty.Easy.DifficultyToStringUpper());
        result.Add(Difficulty.Intermediate.DifficultyToStringUpper());
        result.Add(Difficulty.Hard.DifficultyToStringUpper());
        return result;
    }
    #endregion
}
