using Games.Data.Extensions;
namespace Games.Data.Enums;

public static class EnumsList
{
    public static HashSet<string> GetGameTypeList()
    {
        HashSet<string> result = new();
        result.Add(GameType.TicTacToe.GameTypeToStringUpper());
        result.Add(GameType.Chess.GameTypeToStringUpper());
        return result;
    }

    public static HashSet<string> GetDifficultyList()
    {
        HashSet<string> result = new();
        result.Add(Difficulty.Easy.DifficultyToStringUpper());
        result.Add(Difficulty.Intermediate.DifficultyToStringUpper());
        result.Add(Difficulty.Hard.DifficultyToStringUpper());
        return result;
    }
}