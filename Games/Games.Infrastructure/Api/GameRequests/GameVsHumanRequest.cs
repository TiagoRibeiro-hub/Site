using Games.Infrastructure.Game;

namespace Games.Infrastructure.Api;

public class GameVsHumanRequest
{
    public GameVsHumanRequest(int idGame, Player player, string moveTo, HashSet<int> possibleMoves)
    {
        IdGame = idGame;
        Player = player;
        MoveTo = moveTo;
        PossibleMoves = possibleMoves;
    }

    public int IdGame { get; set; }
    public Player Player { get; set; }
    public string MoveTo { get; set; }
    public HashSet<int> PossibleMoves { get; set; }
}
