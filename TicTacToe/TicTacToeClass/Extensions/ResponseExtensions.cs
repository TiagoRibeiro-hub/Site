using TicTacToe;

namespace TicTacToeClass;

public static class ResponseExtensions
{
    public static GameResponse SetGameResponseFromWinner(this Winner x, List<int> possibleMoves)
    {
        return new GameResponse()
        {
            IdGame = x.GameId,
            HaveWinner = x.HaveWinner,
            WinnerName = x.WinnerName,
            State = x.State,
            GameFinished = x.GameFinished,
            PossibleMoves = possibleMoves,
        };
    }
}

