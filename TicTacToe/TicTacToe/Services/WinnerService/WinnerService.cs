﻿using Microsoft.EntityFrameworkCore;
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
            x.Move
        }).Where(x => x.GameId == game.GameId && x.PlayerName == game.Player.Name)
        .Select(x => x.Move).ToHashSet();

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
            game.Player.Moves.ListPlayedMoves.Add(game.Player.Moves.Move);
            winner.HaveWinner = WinnerFuncs.HaveWinnerMethod(game.Player.Moves.ListPlayedMoves);

            winner.HaveWinner = false; ///////////////////
            if (winner.HaveWinner)
            {
                winner.WinnerName = game.Player.Name;
                winner.GameFinished = true;
                winner.State = GameState.Winner.ToString();
            }
            else
            {
                (winner.GameFinished, winner.State) = WinnerFuncs.IsFinished(game.Player.Moves.ListPlayedMoves.Count());
            }
            winner.GameFinished = true; winner.State = GameState.Tie.ToString();/////////////////
            return Task.FromResult(winner);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

