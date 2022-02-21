namespace Games.Data.Api;

public class PlayResponse
{
    public PlayResponse()
    {

    }
    // Humans
    public PlayResponse(
        int idGame, string? playerName,
        string? gameState, string? gameResult, Dictionary<string, string> possibleMoves)
    {
        IdGame = idGame;
        PlayerName = playerName;
        GameState = gameState;
        GameResult = gameResult;
        PossibleMoves = possibleMoves;
    }

    // Computer
    public PlayResponse(
        int idGame, string? gameState, string? gameResult,
        bool? isComputer, string? difficulty, Dictionary<string, string> possibleMoves)
    {
        IdGame = idGame;
        GameState = gameState;
        GameResult = gameResult;
        IsComputer = isComputer;
        Difficulty = difficulty;
        PossibleMoves = possibleMoves;
    }

    public int IdGame { get; set; }
    public string? PlayerName { get; set; }
    public string? GameState { get; set; }
    public string? GameResult { get; set; }
    public bool? IsComputer { get; set; }
    public string? Difficulty { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}


public class PlayTicTacToeResponse : PlayResponse
{
    public PlayTicTacToeResponse(
    int idGame, string? playerName,
    string? gameState, string? gameResult,
    Dictionary<string, string> possibleMoves, int numberColumns) : base(idGame, playerName, gameState, gameResult, possibleMoves)
    {
        NumberColumns = numberColumns;
    }

    public PlayTicTacToeResponse(
    int idGame, string? gameState, string? gameResult,
    bool? isComputer, string? difficulty, Dictionary<string, string> possibleMoves,
    int numberColumns) : base(idGame, gameState, gameResult, isComputer, difficulty, possibleMoves)
    {
        NumberColumns = numberColumns;
    }

    public int NumberColumns { get; set; }
}