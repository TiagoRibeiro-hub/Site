using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;

namespace TicTacToe.Services;
public class WinnerService : IWinnerService
{
    private readonly TicTacToeDbContext _db;

    public WinnerService(TicTacToeDbContext db)
    {
        _db = db;
    }

    public Task<HashSet<int>> GetListMovesAsync(Game game)
    {

        var playerMoves = _db.Moves.Select(x => new
        {
            x.GameId,
            x.PlayerName,
            x.MoveTo
        }).Where(x => x.GameId == game.GameId && x.PlayerName == game.Player.Name)
        .Select(x => int.Parse(x.MoveTo)).ToHashSet();

        if(playerMoves is null)
        {
            throw new Exception();
        }
        return Task.FromResult(playerMoves);
    }
    public Task<Winner> GetWinnerAsync(Game game)
    {
        try
        {
            Winner winner = new();
            winner.GameId = game.GameId;
            game.Player.Moves.ListPlayedMoves.Add(int.Parse(game.Player.Moves.MoveTo));
            winner.HaveWinner = WinnerFuncs.HaveWinnerMethod(game.Player.Moves.ListPlayedMoves);

            if (winner.HaveWinner)
            {
                winner.WinnerName = game.Player.Name;
                winner.GameFinished = true;
                winner.State = GameState.Winner.ToString();
            }
            else
            {
                (winner.GameFinished, winner.State) = WinnerFuncs.IsFinished(game.PossibleMoves.Count());
            }

            return Task.FromResult(winner);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

