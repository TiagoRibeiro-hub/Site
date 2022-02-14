namespace Games.Infrastructure.Api;

public class GameVsComputerResponse : GameResponse
{
    public GameVsComputerResponse(int idGame) : base(idGame)
    {

    }
    public GameVsComputerResponse(int idGame, string player, string gameState,
        string? gameResult, HashSet<int> possibleMoves, string difficulty) : base(idGame, player, gameState, gameResult, possibleMoves)
    {
        IdGame = idGame;
        PlayerName = player;
        GameState = gameState;
        GameResult = gameResult;
        PossibleMoves = possibleMoves;
        Difficulty = difficulty;
    }

    public string Difficulty { get; set; }
}