using Data.Infrastructure.Data.Game.Player;

namespace Data.Infrastructure.Infrastructure.Api.PlayGame;

public class PlayTicTacToeResponse : PlayResponse
{
    public PlayTicTacToeResponse()
    {

    }
    public PlayTicTacToeResponse(
        Guid idGame, string playerName, string gameState, 
        string gameResult, VsComputer vsComputer, 
        Dictionary<string, string> possibleMoves, int ticTacToeNumberColumns) : base(idGame, playerName, gameState, gameResult, vsComputer, possibleMoves)
    {
        TicTacToeNumberColumns = ticTacToeNumberColumns;
    }

    public int TicTacToeNumberColumns { get; set; }
}