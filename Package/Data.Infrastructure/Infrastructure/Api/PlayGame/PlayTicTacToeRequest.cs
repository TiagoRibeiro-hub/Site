using Data.Infrastructure.Data.Game.Moves;
using Data.Infrastructure.Data.Game.Player;

namespace Data.Infrastructure.Infrastructure.Api.PlayGame;

public class PlayTicTacToeRequest
{
    public PlayTicTacToeRequest(int ticTacToeNumberColumns, Guid idGame, string playerName, VsComputer vsComputer, Movement movements, Dictionary<string, string> possibleMoves)
    {
        TicTacToeNumberColumns = ticTacToeNumberColumns;
        IdGame = idGame;
        PlayerName = playerName;
        VsComputer = vsComputer;
        Movements = movements;
        PossibleMoves = possibleMoves;
    }

    public int TicTacToeNumberColumns { get; set; }
    public Guid IdGame { get; set; }
    public string PlayerName { get; set; }
    public VsComputer VsComputer { get; set; }
    public Movement Movements { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}