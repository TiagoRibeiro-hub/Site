namespace Games.Data.Api;

public class GameVsComputerResponse : GameResponse
{
    public GameVsComputerResponse(int idGame, Dictionary<string, string> possibleMoves) : base(idGame, possibleMoves)
    {

    }
    public GameVsComputerResponse(int idGame, string player, string gameState,
        string? gameResult, Dictionary<string, string> possibleMoves, string difficulty) : base(idGame, player, gameState, gameResult, possibleMoves)
    {
        IdGame = idGame;
        PlayerName = player;
        GameState = gameState;
        GameResult = gameResult;
        PossibleMoves = possibleMoves;
        Difficulty = difficulty;
    }

    public string? Difficulty { get; set; }
}