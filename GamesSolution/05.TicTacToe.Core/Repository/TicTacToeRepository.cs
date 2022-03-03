using _00.Data._Entities;
using _06.TicTacToe.Infrastructure.Data;

namespace _05.TicTacToe.Core.Repository;

public class TicTacToeRepository : ITicTacToeRepository
{
    private readonly TicTacToeDbContext _dbContext;

    public TicTacToeRepository(TicTacToeDbContext dbContext)
    {
        _dbContext = dbContext;

        GetTicTacToeGameRead = new TicTacToeRead<GameEntity>(_dbContext);
        GetTicTacToeGameWrite = new TicTacToeWrite<GameEntity>(_dbContext);

        GetTicTacToeMovesRead = new TicTacToeRead<MovesEntity>(_dbContext);
        GetTicTacToeMovesWrite = new TicTacToeWrite<MovesEntity>(_dbContext);
    }

    public ITicTacToeRead<GameEntity> GetTicTacToeGameRead {get; private set;}
    public ITicTacToeWrite<GameEntity> GetTicTacToeGameWrite { get; private set; }
    public ITicTacToeRead<MovesEntity> GetTicTacToeMovesRead { get; private set; }
    public ITicTacToeWrite<MovesEntity> GetTicTacToeMovesWrite { get; private set; }

    public async Task Complete()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
