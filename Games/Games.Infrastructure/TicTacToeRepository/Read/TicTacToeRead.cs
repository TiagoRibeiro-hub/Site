using Games.Data;
using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public class TicTacToeRead : ReadRepository<GameEntity>, ITicTacToeRead
{
    public TicTacToeRead(TicTacToeDbContext dbContext) : base(dbContext)
    {

    }

    public TicTacToeDbContext RegisteredPlayersDb
    {
        get { return _dbContext as TicTacToeDbContext; }
    }
}