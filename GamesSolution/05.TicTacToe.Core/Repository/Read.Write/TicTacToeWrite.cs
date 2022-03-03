using _00.Infrastructure.Repository.Write;
using _06.TicTacToe.Infrastructure.Data;

namespace _05.TicTacToe.Core.Repository;

public class TicTacToeWrite<TEntity> : WriteRepository<TEntity>, ITicTacToeWrite<TEntity> where TEntity : class
{
    public TicTacToeWrite(TicTacToeDbContext dbContext) : base(dbContext)
    {

    }
}

public interface ITicTacToeWrite<TEntity> : IWriteRepository<TEntity>  where TEntity : class
{

}
