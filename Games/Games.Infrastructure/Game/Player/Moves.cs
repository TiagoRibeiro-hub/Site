namespace Games.Infrastructure.Game;

public class Moves
{
    public Moves()
    {

    }
    public Moves(int gameId, string playerName, string moveTo, int moveNumber, HashSet<int> listPlayedMoves)
    {
        GameId = gameId;
        PlayerName = playerName;
        MoveTo = moveTo;
        MoveNumber = moveNumber;
        ListPlayedMoves = listPlayedMoves;
    }

    public Moves(int gameId, string playerName, string moveTo, string moveFrom, int moveNumber, HashSet<int> listPlayedMoves)
    {
        GameId = gameId;
        PlayerName = playerName;
        MoveTo = moveTo;
        MoveFrom = moveFrom;
        MoveNumber = moveNumber;
        ListPlayedMoves = listPlayedMoves;
    }

    public int GameId { get; set; }
    public string PlayerName { get; set; }
    public string MoveTo { get; set; }
    public string MoveFrom { get; set; }
    public int MoveNumber { get; set; } 
    public HashSet<int> ListPlayedMoves { get; set; } = new();
}
