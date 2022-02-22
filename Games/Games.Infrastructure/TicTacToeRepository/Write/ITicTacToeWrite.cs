using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public interface ITicTacToeWrite<TEntity> : IRepository<TEntity> where TEntity : class
{

}
