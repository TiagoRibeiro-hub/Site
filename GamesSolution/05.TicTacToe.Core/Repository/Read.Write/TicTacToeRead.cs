using _00.Infrastructure.Repository.Read;
using _06.TicTacToe.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace _05.TicTacToe.Core.Repository;
public class TicTacToeRead<TEntity> : ReadRepository<TEntity>, ITicTacToeRead<TEntity> where TEntity : class
{
    public TicTacToeRead(TicTacToeDbContext dbContext) : base(dbContext)
    {
    }
}

public interface ITicTacToeRead<TEntity> : IReadRepository<TEntity> where TEntity : class
{

}
