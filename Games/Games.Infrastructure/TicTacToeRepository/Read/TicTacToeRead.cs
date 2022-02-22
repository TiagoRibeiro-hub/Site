using Games.Data;
using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public class TicTacToeRead<TEntity> : ReadRepository<TEntity>, ITicTacToeRead<TEntity> where TEntity : class
{
    public TicTacToeRead(TicTacToeDbContext dbContext) : base(dbContext)
    {

    }

    public TicTacToeDbContext RegisteredPlayersDb
    {
        get { return _dbContext as TicTacToeDbContext; }
    }
}