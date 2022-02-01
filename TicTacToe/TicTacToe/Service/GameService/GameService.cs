using TicTacToe.Data;
namespace TicTacToe.Service;
public class GameService : IGameService
{
    private readonly TicTacToeDbContext _db;
    private readonly IScoreService _scoreService;
    public GameService(TicTacToeDbContext db, IScoreService scoreService)
    {
        _db = db;
        _scoreService = scoreService;
    }

    public async Task InitializeGame(Human player1, Human player2, Computer computer, Guid guid)
    {
        try
        {
            GameModel model = new()
            {
                IdGame = guid,
                Player1_Name = player1.Name,
            };
            if (computer.Active)
            {
                model.Player2_Name = computer.Name;
                model.IsComputer = true;
            }
            else
            {
                model.Player2_Name = player2.Name;
            }

            await _db.AddAsync(model);
            var save = _db.SaveChangesAsync();
            save.Start();
        }
        catch (Exception)
        {
            throw;
        }
        
    }
    public async Task TableScoreInitializeVsHuman(Human player1, Human player2)
    {
        try
        {
            var task1 = RegisterPlayerAsync(player1);
            task1.Start();
            var task2 = RegisterPlayerAsync(player2);
            task2.Start();

            ScoresTableModel model1 = new();
            model1 = await task1;

            ScoresTableModel model2 = new();
            model2 = await task2;

            _db.ScoresTable.UpdateRange(model1, model2);
            var save = _db.SaveChangesAsync();
            save.Start();
        }
        catch (Exception)
        {
            throw;
        }
    }
    private async Task<ScoresTableModel> RegisterPlayerAsync(Human player)
    {
        try
        {
            bool isReg = _db.ScoresTable.Any(x => x.Email == player.Email);
            ScoresTableModel model = new();
            if (!isReg)
            {
                model.Email = player.Email;
                model.PlayerName = player.Name;
                var task = _db.ScoresTable.AddAsync(model);
                task.AsTask().Start();
            }
            else
            {
                model = await _scoreService.ScoresTableVsHumanAsync(player.Email);
            }
            return model;
        }
        catch (Exception)
        {
            throw;
        }   
    }
    public Task TableScoreInitializeVsComputer(Human player1, Computer computer)
    {
        return Task.CompletedTask;
    }

}

