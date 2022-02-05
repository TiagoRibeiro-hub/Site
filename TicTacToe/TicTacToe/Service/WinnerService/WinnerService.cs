using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;

namespace TicTacToe.Service;
public class WinnerService : IWinnerService
{
    private readonly TicTacToeDbContext _db;

    public WinnerService(TicTacToeDbContext db)
    {
        _db = db;
    }

    public async Task<HashSet<int>> GetListMovesAsync(Game game)
    {
        var move = await _db.Games.FirstOrDefaultAsync(x => x.Id == game.GameId);
        if (move is null)
        {
            throw new Exception();
        }

        var resPlayerMoves = move.Moves.Select(x => new
        {
            x.Move,
            x.PlayerName,

        }).Where(x => x.PlayerName == game.Player.Name);
        
        var playerMoves = resPlayerMoves.Select(x => x.Move).ToHashSet();
        return playerMoves;
    }

    public Task<Winner> GetWinnerAsync(Game game)
    {
        try
        {
            Winner winner = new();
            winner.HaveWinner = WinnerFuncs.HaveWinnerMethod(game.Player.Moves.ListPlayedMoves);

            if (winner.HaveWinner)
            {
                winner.Name = game.Player.Name;
                winner.GameFinished = true;
                winner.State = GameState.Winner.ToString();
            }
            else
            {
                (winner.GameFinished, winner.State) = WinnerFuncs.IsFinished(game.Player.Moves.ListPlayedMoves.Count());
            }
            return Task.FromResult(winner);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

