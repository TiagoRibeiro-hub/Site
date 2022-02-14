namespace Games.Infrastructure.Api;
public class GameVsComputerRequest
{
    public GameVsComputerRequest(int idGame, string turn, string difficulty, HashSet<int> possibleMoves)
    {
        IdGame = idGame;
        Turn = turn;
        Difficulty = difficulty;
        PossibleMoves = possibleMoves;
    }

    public int IdGame { get; set; }
    public string Turn { get; set; }
    public string Difficulty { get; set; }
    public HashSet<int> PossibleMoves { get; set; }
}
