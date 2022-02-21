using Games.Data;

namespace Games.Infrastructure;

public class TicTacToeRepository : ITicTacToeRepository
{
    public TicTacToeDbContext _dbContext;
    public TicTacToeRepository(TicTacToeDbContext dbContext)
    {
        _dbContext = dbContext;
        TicTacToeWrite = new TicTacToeWrite(_dbContext);
        TicTacToeRead = new TicTacToeRead(_dbContext);
    }
    public ITicTacToeWrite TicTacToeWrite { get; private set; }
    public ITicTacToeRead TicTacToeRead { get; private set; }

    public async Task Complete()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}