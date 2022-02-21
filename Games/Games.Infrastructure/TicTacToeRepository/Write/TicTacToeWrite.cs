using Games.Data;
using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public class TicTacToeWrite : Repository<GameEntity>, ITicTacToeWrite
{
    public TicTacToeWrite(TicTacToeDbContext dbContext) : base(dbContext)
    {

    }

    public TicTacToeDbContext RegisteredPlayersDb
    {
        get { return _dbContext as TicTacToeDbContext; }
    }
}
