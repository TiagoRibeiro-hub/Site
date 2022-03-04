using Data.Infrastructure.Infrastructure.Api.PlayGame;

namespace _01.Play.TicTacToe.Infrastructure;
public static class Extensions
{
    public static PlayTicTacToeRequest SetPlayTicTacToeRequest(this PlayTicTacToeRecord x)
    {
        return new PlayTicTacToeRequest
            (
                ticTacToeNumberColumns: x.TicTacToeNumberColumns,
                idGame: x.IdGame,
                playerName: x.playerName,
                vsComputer: x.VsComputer,
                movements: x.Movements,
                possibleMoves: x.PossibleMoves
            );
    }
}
