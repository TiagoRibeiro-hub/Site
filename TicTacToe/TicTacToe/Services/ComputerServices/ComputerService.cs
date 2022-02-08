using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;
using TicTacToe.DbActionService;

namespace TicTacToe.Services;
public class ComputerService : IComputerService
{
    private readonly TicTacToeDbContext _db;
    public readonly IDbActionService _dbActionService;
    public ComputerService(IDbActionService dbActionService, TicTacToeDbContext db)
    {
        _dbActionService = dbActionService;
        _db = db;
    }

    public Task<int> GetEasyPlayedMoveAsync(Game game)
    {
        try
        {
            if (game.PossibleMoves.Count == 9)
            {
                return Task.FromResult(5);
            }
            if (game.PossibleMoves.Count == 8)
            {
                if (game.PossibleMoves.Contains(5))
                {
                    return Task.FromResult(5);
                }
                else
                {
                    return Task.FromResult(ComputerServiceFuncs.GetRandomMove(game.PossibleMoves));
                }
            }
            if (game.PossibleMoves.Count <= 7)
            {
                HashSet<int> opponentMoves = new();
                var isAny = _db.Moves.Select(x => new
                {
                    x.GameId,
                    x.Move,
                    x.PlayerName
                }).Where(x => x.GameId == game.GameId && x.PlayerName != game.Player.Name).ToHashSet();
                if (isAny.Any())
                {
                    opponentMoves = isAny.Select(x => x.Move).ToHashSet();
                    if (!opponentMoves.Any())
                    {
                        throw new Exception();
                    }
                    int move = ComputerServiceFuncs.GetMove(game.PossibleMoves.ToHashSet(), opponentMoves);
                    if (move != 0)
                    {
                        return Task.FromResult(move);
                    }
                }
                else
                {
                    throw new Exception();
                }

            }
            return Task.FromResult(ComputerServiceFuncs.GetRandomMove(game.PossibleMoves));
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    
    public Task<int> GetIntermediatePlayedMoveAsync(Game game)
    {
        try
        {
            MinimaxMoves human = new();
            MinimaxMoves computer = new();
            // Turn
            MinimaxFuncs.ChangeTurn(game.PossibleMoves.ToHashSet(), human, computer);
            // Copy the current game
            HashSet<int> possibleMovesCopy = MinimaxFuncs.CopyPossibleMoves(game.PossibleMoves.ToHashSet());
            // List played moves both players
            var isAny = _db.Moves.Select(x => new
            {
                x.GameId,
                x.Move,
                x.PlayerName
            }).Where(x => x.GameId == game.GameId).ToHashSet();
            if (isAny.Any())
            {
                (human.ListPlayedMoves, computer.ListPlayedMoves) = MinimaxFuncs.GetPlayedMoves(isAny, game.Player.Name);
            }
            else
            {
                throw new Exception();
            }

            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
   



    public Task<int> GetHardPlayedMoveAsync(Game game)
    {
        try
        {
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

}

