namespace TicTacToe.Service;
public class WinnerService : IWinnerService
{
    public Task<Winner> GetWinnerAsync(Game game)
    {
        try
        {
            Winner winner = new();
            winner.HaveWinner = WinnerFuncs.HaveWinnerMethod(game.Player.ListPlayedMoves);

            if (winner.HaveWinner)
            {
                winner.Name = game.Player.Name;
                winner.GameFinished = true;
                winner.State = GameState.Winner.ToString();
            }
            else
            {
                (winner.GameFinished, winner.State) = WinnerFuncs.IsFinished(game.Player.ListPlayedMoves.Count());
            }
            return Task.FromResult(winner);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

