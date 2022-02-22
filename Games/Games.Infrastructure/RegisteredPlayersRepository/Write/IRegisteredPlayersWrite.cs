using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public interface IRegisteredPlayersWrite<TEntity> : IRepository<TEntity> where TEntity : class
{

}
