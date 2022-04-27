using Data.Infrastructure.Data._Entities;
using Data.Infrastructure.Infrastructure.Api.PlayGame;

namespace _01.Play.TicTacToe.Infrastructure;
#nullable disable
public static class Extensions
{
    public static PlayTicTacToeRequest SetPlayTicTacToeRequest(this PlayTicTacToeRecord x)
    {
        return new PlayTicTacToeRequest
            (
                ticTacToeNumberColumns: x.TicTacToeNumberColumns,
                idGame: x.IdGame,
                playerName: x.PlayerName,
                vsComputer: x.VsComputer,
                movements: x.Movements,
                possibleMoves: x.PossibleMoves
            );
    }

    public static MovesEntity SetMovesEntity(this PlayTicTacToeRecord x)
    {
        return new MovesEntity
            (
                gameId: x.IdGame,
                playerName: x.PlayerName,
                moveTo: x.Movements.MoveTo,
                moveFrom: x.Movements.MoveFrom,
                moveNumber: x.Movements.MoveNumber
            );
    }

    public static PlayTicTacToeResponse SetPlayResponse(this PlayTicTacToeRecord x)
    {
        return new PlayTicTacToeResponse
            (
                ticTacToeNumberColumns: x.TicTacToeNumberColumns,
                idGame: x.IdGame,
                playerName: x.PlayerName,
                gameState: null,
                gameResult: null,
                vsComputer: x.VsComputer,
                possibleMoves: x.PossibleMoves
            );
    }
}
