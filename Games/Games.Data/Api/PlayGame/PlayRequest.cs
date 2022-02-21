namespace Games.Data.Api;
#nullable disable
public class PlayRequest
{
    public string GameType { get; set; }
    public PlayTicTacToe PlayTicTacToe { get; set; }
    public int IdGame { get; set; }
    public bool IsComputer { get; set; }
    public string Difficulty { get; set; }
    public string PlayerName { get; set; }
    public int MoveNumber { get; set; }
    public string MoveTo { get; set; }
    public string MoveFrom { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}

public class PlayTicTacToe
{
    public int NumberColumns { get; set; }
}

