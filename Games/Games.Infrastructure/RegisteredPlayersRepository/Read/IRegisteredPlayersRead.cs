using Games.Data.Data;
using Repository;

namespace Games.Infrastructure;

public interface IRegisteredPlayersRead<TEntity> : IReadRepository<TEntity> where TEntity : class
{

}
