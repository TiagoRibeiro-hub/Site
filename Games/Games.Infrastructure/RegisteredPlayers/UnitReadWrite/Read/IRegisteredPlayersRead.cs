namespace Games.Infrastructure;

public interface IRegisteredPlayersRead<TEntity> : IReadRepository<TEntity> where TEntity : class
{

}
