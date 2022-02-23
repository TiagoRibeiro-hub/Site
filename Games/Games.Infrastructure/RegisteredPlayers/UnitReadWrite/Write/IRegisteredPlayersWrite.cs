namespace Games.Infrastructure;

public interface IRegisteredPlayersWrite<TEntity> : IRepository<TEntity> where TEntity : class
{

}
