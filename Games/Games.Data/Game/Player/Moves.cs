namespace Games.Data.Game;

public class Moves
{
    public Moves()
    {

    }
    public Moves(int gameId, string playerName, string moveTo, int moveNumber, Dictionary<string, string> listPlayedMoves)
    {
        GameId = gameId;
        PlayerName = playerName;
        MoveTo = moveTo;
        MoveNumber = moveNumber;
        ListPlayedMoves = listPlayedMoves;
    }

    public Moves(int gameId, string playerName, string moveTo, string moveFrom, int moveNumber, Dictionary<string, string> listPlayedMoves)
    {
        GameId = gameId;
        PlayerName = playerName;
        MoveTo = moveTo;
        MoveFrom = moveFrom;
        MoveNumber = moveNumber;
        ListPlayedMoves = listPlayedMoves;
    }

    public int GameId { get; set; }
    public string? PlayerName { get; set; }
    public string? MoveTo { get; set; }
    public string? MoveFrom { get; set; }
    public int MoveNumber { get; set; } 
    public Dictionary<string, string> ListPlayedMoves { get; set; } = new();
}
