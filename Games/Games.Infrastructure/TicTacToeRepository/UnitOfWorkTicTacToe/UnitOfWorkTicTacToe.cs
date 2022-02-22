using Games.Data;

namespace Games.Infrastructure;

public class UnitOfWorkTicTacToe<TEntity> : IUnitOfWorkTicTacToe<TEntity> where TEntity : class
{
    public TicTacToeDbContext _dbContext;
    public UnitOfWorkTicTacToe(TicTacToeDbContext dbContext)
    {
        _dbContext = dbContext;
        TicTacToeWrite = new TicTacToeWrite<TEntity>(_dbContext);
        TicTacToeRead = new TicTacToeRead<TEntity>(_dbContext);
    }
    public ITicTacToeWrite<TEntity> TicTacToeWrite { get; private set; }
    public ITicTacToeRead<TEntity> TicTacToeRead { get; private set; }

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