using ApiShared;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;

namespace TicTacToe.Service;

public class GameDbService : IGameDbService
{
    private readonly TicTacToeDbContext _db;

    public GameDbService(TicTacToeDbContext db)
    {
        _db = db;
    }
    public async Task<int> InsertInitializeGame(GameModel game)
    {
        try
        {
            await _db.AddAsync(game);
            await _db.SaveChangesAsync();
            int gameId = GetGameIdByPlayer(game.Player1_Name);
            MovesModel movesPlayer1 = new()
            {
                GameId = gameId,
                PlayerName = game.Player1_Name,
            };
            MovesModel movesPlayer2 = new()
            {
                GameId = gameId,
                PlayerName = game.Player2_Name,
            };
            await _db.AddRangeAsync(movesPlayer1, movesPlayer2);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
            return gameId;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    
    public async Task RegisterMove(Game game)
    {
        try
        {
            int lastKey = game.Player.ListPlayedMoves.Count();
            int value = game.Player.ListPlayedMoves.GetValueOrDefault(lastKey);
            var move = await _db.Games.FirstOrDefaultAsync(x => x.Id == game.GameId);

            if(move is null)
            {
                throw new Exception();
            }
  
            MovesModel movesPlayer1 = new()
            {
                GameId = game.GameId,
                PlayerName = game.Player.Name,
                MoveNumber = lastKey,
                Move = value,
            };
            move.Moves.Add(movesPlayer1);
            _db.Update(move);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        };
    }

    private int GetGameIdByPlayer(string player1Name)
    {
        try
        {
            var res = _db.Games.Select(x => new { x.Id, x.Player1_Name }).Where(x => x.Player1_Name == player1Name);
            if (res.Any())
            {
                return res.Select(x => x.Id).FirstOrDefault();
            }
            return -1;
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

}

