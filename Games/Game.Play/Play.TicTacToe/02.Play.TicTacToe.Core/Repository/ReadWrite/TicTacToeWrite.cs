
using _00.Play.TicTacToe.Data._DbContext;
using Data.Infrastructure.Infrastructure.Repository.Write;

namespace _02.Play.TicTacToe.Core.Repository.ReadWrite;

public class TicTacToeWrite<TEntity> : WriteRepository<TEntity>, ITicTacToeWrite<TEntity> where TEntity : class
{
    public TicTacToeWrite(TicTacToeDbContext dbContext) : base(dbContext)
    {

    }
}

public interface ITicTacToeWrite<TEntity> : IWriteRepository<TEntity> where TEntity : class
{

}
