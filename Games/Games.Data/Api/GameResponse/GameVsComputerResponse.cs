namespace Games.Data.Api;

public class GameVsComputerResponse : GameResponse
{
    public GameVsComputerResponse()
    {

    }
    public GameVsComputerResponse(int idGame, string gameState, Dictionary<string, string> possibleMoves, int ticTacToeNrCol) : base(idGame, gameState, possibleMoves, ticTacToeNrCol)
    {

    }
    public GameVsComputerResponse(int idGame, string player, string gameState,
        string? gameResult, Dictionary<string, string> possibleMoves, int ticTacToeNrCol, string difficulty) : base(idGame, player, gameState, gameResult, possibleMoves, ticTacToeNrCol)
    {
        Difficulty = difficulty;
    }

    public string? Difficulty { get; set; }
}