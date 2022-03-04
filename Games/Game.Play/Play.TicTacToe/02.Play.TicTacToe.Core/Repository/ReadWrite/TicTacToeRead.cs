using _00.Play.TicTacToe.Data._DbContext;
using Data.Infrastructure.Infrastructure.Repository.Read;

namespace _02.Play.TicTacToe.Core.Repository.ReadWrite;
public class TicTacToeRead<TEntity> : ReadRepository<TEntity>, ITicTacToeRead<TEntity> where TEntity : class
{
    public TicTacToeRead(TicTacToeDbContext dbContext) : base(dbContext)
    {
    }
}

public interface ITicTacToeRead<TEntity> : IReadRepository<TEntity> where TEntity : class
{

}

