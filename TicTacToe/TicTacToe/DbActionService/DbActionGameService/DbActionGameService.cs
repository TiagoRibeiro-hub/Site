using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public class DbActionGameService : IDbActionGameService
{
    private readonly TicTacToeDbContext _db;

    public DbActionGameService(TicTacToeDbContext db)
    {
        _db = db;
    }

    public async Task<bool> IsRegisterByPlayerName(string playerName)
    {
        try
        {
            bool isReg = await _db.ScoresTable.AnyAsync(x => x.PlayerName == playerName);
            if (isReg)
            {
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public async Task InsertScoresTableAsync(ScoresTableModel scoreTable)
    {
        try
        {
            await _db.ScoresTable.AddAsync(scoreTable);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public async Task<int> GetScoresTableIDByPlayerNameAsync(string playerName)
    {
        try
        {
            var res = await _db.ScoresTable.Select(x => new
            {
                x.Id,
                x.PlayerName
            }).Where(x => x.PlayerName == playerName).FirstOrDefaultAsync();

            if(res is null)
            {
                throw new Exception();
            }

            return res.Id;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task<ScoresTableModel> GetScoresTableByPlayerNameAsync(string playerName)
    {
        try
        {
            var scoresTable = await _db.ScoresTable.FirstOrDefaultAsync(x => x.PlayerName == playerName);
            if (scoresTable is null)
            {
                throw new Exception();
            }
            return scoresTable;
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

            var move = await _db.Games.FirstOrDefaultAsync(x => x.Id == game.GameId);
            if (move is null)
            {
                throw new Exception();
            }

            MovesModel movesPlayer = new()
            {
                GameId = game.GameId,
                PlayerName = game.Player.Name,
                Move = game.Player.Moves.Move,
            };
            if (game.Player.Moves.IsfirstMove)
            {
                movesPlayer.MoveNumber = 1;
            }
            else
            {
                var lastTurn = move.Moves.Select(x => new
                {
                    x.MoveNumber,
                    x.PlayerName
                }).Where(x => x.PlayerName == game.Player.Name).Max();
                if (lastTurn is null)
                {
                    throw new Exception();
                }
                movesPlayer.MoveNumber = lastTurn.MoveNumber + 1;
            }
            move.Moves.Add(movesPlayer);
            _db.Update(move);
            await _db.SaveChangesAsync();
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        };
    }


}

