using TicTacToe;
using TicTacToe.Data;

namespace TicTacToeClass;

public static class DataModelExtensions
{
    public static MovesModel SetMovesModelFromMoves(this Moves x)
    {
        return new MovesModel()
        {
            PlayerName = x.PlayerName,
            GameId = x.GameId,
            MoveTo = x.MoveTo,
            MoveNumber = x.MoveNumber,
        };
    }

    public static MovesModel SetMovesModelFromGame(this Game x, int lastMove)
    {
        Moves moves = new()
        {
            GameId = x.GameId,
            PlayerName = x.Player.Name,
            MoveTo = x.Player.Moves.MoveTo,
            MoveNumber = lastMove + 1
        };
        return moves.SetMovesModelFromMoves();
    }
}

