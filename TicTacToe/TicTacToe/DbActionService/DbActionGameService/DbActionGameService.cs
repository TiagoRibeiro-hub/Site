using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;
using TicTacToeClass;

namespace TicTacToe.DbActionService;
public class DbActionGameService : IDbActionGameService
{
    private readonly TicTacToeDbContext _db;
    private readonly IDbActionService _dbActionService;
    public DbActionGameService(TicTacToeDbContext db, IDbActionService dbActionService)
    {
        _db = db;
        _dbActionService = dbActionService;
    }


    public async Task<(string, string)> GetPlayersGameByGameIdAsync(int gameId)
    {
        try
        {
            var players = await _db.Games.Select(x => new
            {
                x.Id,
                x.Player1_Name,
                x.Player2_Name
            }).Where(x => x.Id == gameId).FirstOrDefaultAsync();

            if (players is null)
            {
                throw new Exception();
            }

            return (players.Player1_Name, players.Player2_Name);
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task<int> InsertInitializeGame(GameModel game, HashSet<Moves> listPlayerMovesInit)
    {
        try
        {
            await _dbActionService.InsertAsync(game);
            var gameId = await _db.Games.Select(x => new
            {
                x.Id,
                x.Player1_Name,
                x.Player2_Name
            }).Where(x => x.Player1_Name == game.Player1_Name && x.Player2_Name == game.Player2_Name).MaxAsync(x => x.Id);

            MovesModel movesModelPlayer1 = new();
            MovesModel movesModelPlayer2 = new();
            int count = 0;
            foreach (var moves in listPlayerMovesInit)
            {
                moves.GameId = gameId;
                if (count == 0)
                {
                    movesModelPlayer1 = moves.SetMovesModelFromMoves();
                }
                else
                {
                    movesModelPlayer2 = moves.SetMovesModelFromMoves();
                }
                count += 1;
            }
            await _dbActionService.InsertRangeAsync(movesModelPlayer1, movesModelPlayer2);
            Task.CompletedTask.Wait();
            return gameId;
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
    public async Task RegisterMove(Game game)
    {
        try
        {
            var isAny = _db.Moves.Select(x => new
            {
                x.GameId,
                x.MoveNumber
            }).Where(x => x.GameId == game.GameId).ToHashSet();
            int lastMove = 0;
            if (isAny.Any())
            {
                lastMove = isAny.Max(x => x.MoveNumber);
            }
            MovesModel movesPlayer = game.SetMovesModelFromGame(lastMove);
            await _dbActionService.InsertAsync(movesPlayer);
            Task.CompletedTask.Wait();
        }
        catch (Exception)
        {
            throw new Exception();
        };
    }
}


