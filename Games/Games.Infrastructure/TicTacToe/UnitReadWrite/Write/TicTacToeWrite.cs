namespace Games.Infrastructure;
#nullable disable
public class TicTacToeWrite<TEntity> : Repository<TEntity>, ITicTacToeWrite<TEntity> where TEntity : class
{
    public TicTacToeWrite(TicTacToeDbContext dbContext) : base(dbContext)
    {

    }

    public TicTacToeDbContext RegisteredPlayersDb
    {
        get { return _dbContext as TicTacToeDbContext; }
    }
}
