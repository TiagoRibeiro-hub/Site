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
            Task.CompletedTask.Wait();
            return gameId;
        }
        catch (Exception)
        {
            throw new Exception();
        }
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

