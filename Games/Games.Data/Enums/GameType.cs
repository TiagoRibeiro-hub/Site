using Games.Data.Extensions;

namespace Games.Data.Enums;

public enum GameType
{
    TicTacToe,
    Chess
}

public static class GameTypeEnum
{
    public static HashSet<string> GetList()
    {
        HashSet<string> result = new();
        result.Add(GameType.TicTacToe.GameTypeToStringUpper());
        result.Add(GameType.Chess.GameTypeToStringUpper());
        return result;
    }
}
