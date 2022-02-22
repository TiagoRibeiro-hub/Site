using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public interface ITicTacToeRead<TEntity> : IReadRepository<TEntity> where TEntity : class
{

}
